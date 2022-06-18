using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class ContaEspecial : ContaCorrente
    {
        public double Limite { get; set; }
        public ContaEspecial(int banco, string agencia, string conta) : base(banco, agencia, conta)
        {
        }
        public ContaEspecial(int banco, string agencia, string conta, Cliente cliente) : this(banco, agencia, conta)
        {
            this.ClienteInfo = cliente;
        }
        public ContaEspecial(int banco, string agencia, string conta, Cliente cliente, double limite) : this(banco, agencia, conta)
        {
            this.ClienteInfo = cliente;
            this.Limite = limite;
        }

        //métodos sobrescritos
        public override void EfetuarOperacao(double valor, Operacoes operacao = Operacoes.Deposito)
        {
            switch (operacao)
            {
                case Operacoes.Deposito:
                    this.Saldo += valor;
                    break;
                case Operacoes.Saque:
                    if (valor <= (this.Saldo + this.Limite))
                    {
                        this.Saldo -= valor;
                    }
                    break;
            }
            base.RegistrarMovimento(valor, operacao);
        }
        public override string Exibir()
        {
            return $"{base.Exibir()}\nLimite: {this.Limite}\nSalto Disponível: {this.Saldo + this.Limite}";
        }
        public override string MostrarExtrato()
        {
            return new StringBuilder(base.MostrarExtrato())
                        .Append($"\nLimite: {this.Limite:c}")
                        .Append($"\nSaldo Disponível: {this.Limite + this.Saldo: c}")
                        .ToString();
    }
}
}
