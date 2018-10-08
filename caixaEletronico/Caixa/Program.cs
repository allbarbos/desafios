using System;

namespace Caixa
{
  internal class Program
  {
    public static bool Ligado = true;

    public static CaixaEletronico Caixa = new CaixaEletronico();

    private static void Main(string[] args)
    {
      while (Ligado)
      {
        Console.Clear();
        Console.WriteLine($"Caixa Iniciado!\n");

        EmOperacao();
      }

      Environment.Exit(1);
    }

    private static void EmOperacao()
    {
      Console.WriteLine("1 - Deposito");
      Console.WriteLine("2 - Saldo");
      Console.WriteLine("3 - Saque");
      Console.WriteLine("4 - Extrato");
      Console.WriteLine("0 - Desligar");

      var opcao = Console.ReadKey();

      if (opcao.Key.ToString().Equals("D0"))
        Ligado = false;

      switch (opcao.Key.ToString())
      {
        case "D1":
          {
            Console.WriteLine("\n\nQual o valor da cédula? (5 - 10 - 20 - 50 - 100)");
            var valor = Console.ReadLine();

            Console.WriteLine("Qual a quantidade de cédula?");
            var quantidade = Console.ReadLine();

            int qtd;
            if (int.TryParse(quantidade, out qtd))
            {
              if (Caixa.Deposito(valor, qtd))
              {
                Console.WriteLine("Deposito confirmado!");
                Console.ReadKey();
                break;
              }
            }

            Console.WriteLine("Deposito inválido!");
            Console.ReadKey();
            break;
          }

        case "D2":
          {
            Caixa.Saldo();
            Console.ReadKey();
            break;
          }

        case "D3":
          {
            Console.WriteLine("\n\nQual valor deseja sacar?");
            var saque = Console.ReadLine();

            int valor;
            if (int.TryParse(saque, out valor))
            {
              if (Caixa.VerificaLimite(valor))
              {
                Caixa.Saque(valor);
                Console.ReadKey();
                break;
              }

              Console.WriteLine($"Caixa não possui R$ {valor} para saque - Limite disponível R$ {Caixa.CalculaTotal()}");
              Console.ReadKey();
              break;
            }

            Console.WriteLine("Saque inválido!");
            Console.ReadKey();
            break;
          }

        case "D4":
          {
            Caixa.Extrato();
            Console.ReadKey();
            break;
          }
      }
    }
  }
}
