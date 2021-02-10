using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Conta
    {
        private AccountType AccountType { get; set; }
        private string Name { get; set; }
        private double Credit { get; set; }
        private double Balance { get; set; }

        public Conta(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Pick(double pickValue)
        {
            if (this.Pick - pickValue < (this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
            this.Balance -= pickValue;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);

            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Balance += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Pick(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.AccountType + " | ";
            retorno += "Nome " + this.Name + " | ";
            retorno += "Saldo " + this.Balance + " | ";
            retorno += "Crédito " + this.Credit;
            return retorno;
        }
    }
}

