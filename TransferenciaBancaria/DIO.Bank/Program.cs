using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank - Listar contas ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta Cadastrada!");
            }
            else
            {
                for (int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(conta);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank - Nova Conta ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.Write(" Tipo de Conta: 1-PF ou 2-PJ: ");
            int entradatipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Titularidade: Digite o nome: ");
            string entradaNome = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.Write(" Depósito inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write(" Crétido especial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradatipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank - Transferências ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.Write(" Informe o número da sua Conta: ");
            int indicaContaSaque = int.Parse(Console.ReadLine());
            Console.Write(" Informe a Conta do favorecido: ");
            int indicaContaDeposito = int.Parse(Console.ReadLine());
            Console.Write(" Informe o valor desejado.: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            listContas[indicaContaSaque].Transferir(valorTransferencia, listContas[indicaContaDeposito]);
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank - Saques ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.Write(" Informe o número da Conta: ");
            int indicaConta = int.Parse(Console.ReadLine());
            Console.Write(" Informe o valor desejado.: ");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indicaConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank - Depóstios ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.Write(" Informe o número da Conta: ");
            int indicaConta = int.Parse(Console.ReadLine());
            Console.Write(" Informe o valor desejado.: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            listContas[indicaConta].Depositar(valorDeposito);
        }

        private static string obterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  DIO Bank a seu dispor ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. Listar contas");
            Console.WriteLine(" 2. Inserir nova conta");
            Console.WriteLine(" 3. Transferir valor");
            Console.WriteLine(" 4. Sacar valor");
            Console.WriteLine(" 5. Depositar valor");
            Console.WriteLine(" C. Limpar Tela");
            Console.WriteLine(" X. Sair");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.Write(" Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
