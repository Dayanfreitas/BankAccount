using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string op = ObterOpcaoUsuario();
            while (op != "X")
            {
                switch (op)
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
                op = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por ultilizar nossos serviços");
            Console.WriteLine();

            // Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0,0, "Dayan");
            // Console.WriteLine(minhaConta.ToString());
            // Conta conta2 = new Conta(TipoConta.PessoaFisica, 0,0, "Eliezer");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }

        private static void InserirConta() 
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para conta Jurídiaca: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite crédito:");
            double credito = double.Parse(Console.ReadLine()); 

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo, credito,nome);
            
            listContas.Add(novaConta);
        }

        private static void ListarContas ()
        {
            Console.WriteLine("Lista contas");

            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada !");
                return;
            }

            for (int i = 0; i < listContas.Count; i++) 
            {
                Conta conta = listContas[i];
                Console.Write("#{0} -", i);
                Console.WriteLine(conta);
            }
        }
        
        private static void Sacar() 
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());
            
            Conta conta = listContas[indiceConta];
            conta.Sacar(valorSaque);
        }

        private static void Depositar() 
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a depositar:");
            double valor = double.Parse(Console.ReadLine());
            
            Conta conta = listContas[indiceConta];
            conta.Depositar(valor);
        }
        private static void Transferir() 
        {
            Console.WriteLine("Digite o número da origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a depositar:");
            double valor = double.Parse(Console.ReadLine());
            
            Conta contaOrigem = listContas[indiceContaOrigem];
            Conta contaDestino = listContas[indiceContaDestino];

            contaOrigem.Transferir(valor, contaDestino);
        }

    }
}
