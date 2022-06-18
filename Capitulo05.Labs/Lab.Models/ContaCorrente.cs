using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class ContaCorrente : Conta
    {
        public double Saldo { get; protected set; }
        public Cliente ClienteInfo { get; set; }


        public ContaCorrente(int banco, string agencia, string conta) : base(banco, agencia, conta)
        {
        }

        public ContaCorrente(int banco, string agencia, string conta, Cliente clienteInfo) : this(banco, agencia, conta)
        {
            ClienteInfo = clienteInfo;
        }

        public virtual void EfetuarOperacao(double valor, Operacoes operacao = Operacoes.Deposito)
        {
            switch (operacao)
            {
                case Operacoes.Deposito:
                    this.Saldo += valor;
                    break;
                case Operacoes.Saque:
                    if (valor <= this.Saldo)
                    {
                        this.Saldo -= valor;
                    }
                    break;
                default:
                    break;
            }
        }

        public virtual string Exibir()
        {
            string cliente = this.ClienteInfo != null ? this.ClienteInfo.Exibir() + "\n" : "";

            return $"{cliente}" +
            $"Banco: {this.NumeroBanco}\n" +
            $"Agência: {this.NumeroAgencia}\n" +
            $"Conta: {this.NumeroConta}\n" +
            $"Saldo Atual: {this.Saldo}";
        }

        public override string MostrarExtrato()
        {
            throw new NotImplementedException();
        }
    }
}
