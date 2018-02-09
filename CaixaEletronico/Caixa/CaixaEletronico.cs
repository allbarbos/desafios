using System;
using System.Collections.Generic;
using System.Linq;

namespace Caixa
{
  public class CaixaEletronico
  {
    public CaixaEletronico()
    {
      Cedulas = new Dictionary<string, int> { { "5", 0 }, { "10", 0 }, { "20", 0 }, { "50", 0 }, { "100", 0 } };

      DepositoLog = new List<DateTime>();

      SaqueLog = new List<DateTime>();
    }

    public Dictionary<string, int> Cedulas { get; private set; }

    public List<DateTime> DepositoLog { get; private set; }

    public List<DateTime> SaqueLog { get; private set; }

    public bool Deposito(string valor, int quantidade)
    {
      if (!Cedulas.ContainsKey(valor) || quantidade <= 0)
        return false;

      Cedulas[valor] += quantidade;
      DepositoLog.Add(DateTime.Now);
      return true;
    }

    public bool VerificaLimite(int valor)
    {
      return CalculaTotal() >= valor;
    }

    public int CalculaTotal()
    {
      return Cedulas.Sum(x => x.Value * Convert.ToInt32(x.Key));
    }

    public void Saldo()
    {
      Console.WriteLine("\n\n### Saldo ###\n");

      foreach (var cedula in Cedulas)
      {
        Console.WriteLine($"Cédula: {cedula.Key} - Quantidade: {cedula.Value}\n");
      }

      Console.WriteLine($"Total: R$ {CalculaTotal()}\n");

      Console.WriteLine("###########################\n");
    }

    public void Saque(int valor)
    {
      var valorCheio = valor;
      var houveSaque = false;

      Console.WriteLine("\n#### Saque ####\n");

      if (valor >= 100 && Cedulas["100"] > 0)
      {
        Debito(ref valor, 100);
        houveSaque = true;
      }

      if (valor >= 50 && Cedulas["50"] > 0)
      {
        Debito(ref valor, 50);
        houveSaque = true;
      }

      if (valor >= 20 && Cedulas["20"] > 0)
      {
        Debito(ref valor, 20);
        houveSaque = true;
      }

      if (valor >= 10 && Cedulas["10"] > 0)
      {
        Debito(ref valor, 10);
        houveSaque = true;
      }

      if (valor >= 5 && Cedulas["5"] > 0)
      {
        Debito(ref valor, 5);
        houveSaque = true;
      }

      if (houveSaque)
      {
        SaqueLog.Add(DateTime.Now);
      }
      else if (valor > 0 && houveSaque)
      {
        Console.WriteLine($"O caixa não possui notas para sacar o restante de R$ {valor}, portanto foi sacado apenas R$ {valorCheio - valor}");
      }
      else if (valor > 0)
      {
        Console.WriteLine($"O caixa não possui notas para sacar R$ {valor}");
      }

      Console.WriteLine("\n###############\n");
    }

    public void Extrato()
    {
      Console.WriteLine("\n\n#### Extrato ####");

      if (DepositoLog.Count > 0)
      {
        Console.WriteLine("\nDepositos:");

        foreach (var deposito in DepositoLog)
        {
          Console.WriteLine($"{deposito.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
      }
      else
        Console.WriteLine("\nNenhum deposito realizado!");

      if (SaqueLog.Count > 0)
      {
        Console.WriteLine("\nSaques:");

        foreach (var saque in SaqueLog)
        {
          Console.WriteLine($"{saque.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
      }
      else
        Console.WriteLine("\nNenhum saque realizado!");

      Console.WriteLine("\n#################\n");
    }

    private void Debito(ref int valor, int cedula)
    {
      var qtdCedulasUtilizadas = valor / cedula;
      valor = valor % cedula;
      Cedulas[cedula.ToString()] -= qtdCedulasUtilizadas;

      Console.WriteLine($"{qtdCedulasUtilizadas} de {cedula}");
    }
  }
}