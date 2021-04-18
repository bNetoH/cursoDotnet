namespace DIO.Bank
{
using System;
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get;set;}
        private double Credito {get;set;}
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) 
        { 
            if(this.Saldo - valorSaque < this.Credito * -1)
            { 
                System.Console.WriteLine("Saldo Insuficiente! ");
                return false;
            }
            this.Saldo -= valorSaque;
            System.Console.WriteLine("Saldo atual da conta de {0} é de R$ {1}", this.Nome, this.Saldo);
            return true; 
        }

        public bool Depositar(double valorDeposito) 
        {
            // poderia/deveria tratar na UI
            if(valorDeposito < 0)
            { 
                System.Console.WriteLine("Operação inválida! ");
                return false;
            }
            this.Saldo += valorDeposito;
            System.Console.WriteLine("Saldo atual da conta de {0} é de R$ {1}", this.Nome, this.Saldo);
            return true; 
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) 
        {
            if (this.Sacar(valorTransferencia)) 
            {
                contaDestino.Depositar(valorTransferencia);
            } 
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}