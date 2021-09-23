using aj_bank.constants;
using System;

namespace aj_bank.model
{
    public class Conta
    {
        public static long NumeroAtual { get; set; }
        public long Numero { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Lis { get; set; }
        public TipoConta Tipo { get; set; }

        public Conta (string nome, double saldo, double lis, TipoConta tipo)
        {
            GerarNumeroConta();
            this.Nome = nome;
            this.Saldo = saldo;
            this.Lis = lis;
            this.Tipo = tipo;
        }

        public bool Sacar(double valor)
        {
            if(ValidarSaque(valor))
            {
                this.Saldo -= valor;
                PrintSaldoAtual();
                return true;
            }
            return false;
        }

        private bool ValidarSaque(double valor)
        {
            if((this.Saldo + this.Lis) < valor )
            {
                Console.WriteLine("Você não possui saldo suficiente para fazer essa transação!");
                return false;
            }
            return true;
        }

        public void Depositar(double valor, bool contaAtual)
        {
            this.Saldo += valor;
            if(contaAtual)
            {
                PrintSaldoAtual();
            }
        }

        public void Transferir(Conta contaTransferencia, double valor)
        {
            if (this.Sacar(valor))
            {
                contaTransferencia.Depositar(valor, false);
            }

        }

        private void PrintSaldoAtual()
        {
            Console.WriteLine(this.Nome);
            Console.WriteLine("Seu saldo atual é de {0} com lis de {1}", this.Saldo, this.Lis);
        }

        private void GerarNumeroConta()
        {
            NumeroAtual++;
            this.Numero += NumeroAtual;
        }

        public override string ToString()
        {
            return $"\t \n-----  {this.Nome} | Conta: {this.Numero} | Saldo: {this.Saldo} | Lis: {this.Lis} -----\n";
        }

    }
}
