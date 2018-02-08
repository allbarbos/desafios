using System;

namespace Caixa
{
  class Program
  {
    public static bool ligado = true;

    public static CaixaEletronico caixa = new CaixaEletronico();

    static void Main(string[] args)
    {
      while (ligado)
      {
        Console.Clear();
        Console.WriteLine($"Caixa Iniciado!\n");

        EmOperacao();
      }

      Environment.Exit(1);
    }

    private static void EmOperacao()
    {
      Console.WriteLine($"1 - Deposito");
      Console.WriteLine($"2 - Saldo");
      Console.WriteLine($"3 - Saque");
      Console.WriteLine($"0 - Desligar");

      var opcao = Console.ReadKey();

      if (opcao.Key.ToString().Equals("D0"))
        ligado = false;

      switch (opcao.Key.ToString())
      {
        case "D1":
          {
            Console.WriteLine($"\n\nQual o valor da cédula? (5 - 10 - 20 - 50 - 100)");
            var valor = Console.ReadLine();

            Console.WriteLine($"Qual a quantidade de cédula?");
            var quantidade = Console.ReadLine();

            int qtd;
            if (int.TryParse(quantidade, out qtd))
            {
              if (caixa.Deposito(valor, qtd))
              {
                Console.WriteLine($"Deposito confirmado!");
                Console.ReadKey();
                break;
              }
            }

            Console.WriteLine($"Deposito inválido!");
            Console.ReadKey();
            break;
          }

        case "D2":
          {
            caixa.Saldo();
            Console.ReadKey();
            break;
          }

        case "D3":
          {
            Console.WriteLine($"\n\nQual valor deseja sacar?");
            var saque = Console.ReadLine();

            int valor;
            if (int.TryParse(saque, out valor))
            {
              if (caixa.VerificaLimite(valor))
              {
                caixa.Saque(valor);
                Console.ReadKey();
                break;
              }

              Console.WriteLine($"Caixa não possui R$ {valor} para saque - Limite disponível R$ {caixa.CalculaTotal()}");
              Console.ReadKey();
              break;
            }

            Console.WriteLine($"Saque inválido!");
            Console.ReadKey();
            break;
          }
      }
    }
  }
}
