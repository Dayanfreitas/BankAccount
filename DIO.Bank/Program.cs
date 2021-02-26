using System;

namespace DIO.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0,0, "Dayan");
            Console.WriteLine(minhaConta.ToString());
            Conta conta2 = new Conta(TipoConta.PessoaFisica, 0,0, "Eliezer");

            Console.WriteLine("Hello World!");
        }
    }
}
