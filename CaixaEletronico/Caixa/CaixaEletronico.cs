using System;
using System.Collections.Generic;
using System.Linq;

namespace Caixa
{
  public class CaixaEletronico
  {
    public CaixaEletronico()
    {
      Cedulas = new Dictionary<string, int>
      {
        { "5", 0 },
        { "10", 0 },
        { "20", 0 },
        { "50", 0 },
        { "100", 0 }
      };
    }

    public Dictionary<string, int> Cedulas { get; private set; }


    public bool Deposito(string valor, int quantidade)
    {
      if (Cedulas.ContainsKey(valor) && quantidade > 0)
      {
        Cedulas[valor] += quantidade;

        return true;
      }

      return false;
    }

    public bool VerificaLimite(int valor)
    {
      if (CalculaTotal() >= valor)
      {
        return true;
      }

      return false;
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
        Debito(ref valor, "100");
        houveSaque = true;
      }

      if (valor >= 50 && Cedulas["50"] > 0)
      {
        Debito(ref valor, "50");
        houveSaque = true;
      }                              
                                     
      if (valor >= 20 && Cedulas["20"] > 0)               
      {
        Debito(ref valor, "20");
        houveSaque = true;
      }                              
                                     
      if (valor >= 10 && Cedulas["10"] > 0)               
      {
        Debito(ref valor, "10");
        houveSaque = true;
      }

      if (valor >= 5 && Cedulas["5"] > 0)
      {
        Debito(ref valor, "5");
        houveSaque = true;
      }

      if (valor > 0 && houveSaque)
      {
        Console.WriteLine($"O caixa não possui notas para sacar o restante de R$ {valor}, portanto foi sacado apenas R$ {valorCheio - valor}");
      }
      else
      {
        Console.WriteLine($"O caixa não possui notas para sacar R$ {valor}");
      }

      Console.WriteLine("\n###############\n");
    }


    private void Debito(ref int valor, string cedula)
    {
      var qtdCedulasUtilizadas = valor / 100;
      valor = valor % 100;
      Cedulas[cedula] -= qtdCedulasUtilizadas;

      Console.WriteLine($"{qtdCedulasUtilizadas} de {cedula}");
    }
  }
}
