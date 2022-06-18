using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class ContaCorrente
    {
        public int NumeroBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; private set; }
        public Cliente ClienteInfo { get; set; }

        public void EfetuarOperacao(double valor, Operacoes operacao = Operacoes.Deposito)
        {
            switch (operacao)
            {
                case Operacoes.Deposito:
                    this.Saldo += valor;
                    break;
                case Operacoes.Saque:
                    this.Saldo -= valor;
                    break;
                default:
                    break;
            }
        }

        public ContaCorrente(int numeroBanco, string numeroAgencia, string numeroConta)
        {
            NumeroBanco = numeroBanco;
            NumeroAgencia = numeroAgencia;
            NumeroConta = numeroConta;
        }

        public ContaCorrente(int numeroBanco, string numeroAgencia, string numeroConta, Cliente clienteInfo) : this(numeroBanco, numeroAgencia, numeroConta)
        {
            ClienteInfo = clienteInfo;
        }

        public string Exibir()
        {
            string cliente = this.ClienteInfo != null ? this.ClienteInfo.Exibir() + "\n" : "";

            return $"{cliente}" +
            $"Banco: {this.NumeroBanco}\n" +
            $"Agência: {this.NumeroAgencia}\n" +
            $"Conta: {this.NumeroConta}\n" +
            $"Saldo Atual: {this.Saldo}";
        }
    }
}
