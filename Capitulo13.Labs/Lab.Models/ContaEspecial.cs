using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class ContaEspecial : ContaCorrente
    {
        private double _limite;
        public double Limite
        {
            get =>_limite;
            set => _limite = value > 0 ? value : throw new InvalidOperationException("O Limite deve ser positivo");
        }

        public ContaEspecial() { }
        public ContaEspecial(int numeroBanco, string numeroAgencia, string numeroConta) : base(numeroBanco, numeroAgencia, numeroConta)
        {

        }
        public ContaEspecial(int numeroBanco, string numeroAgencia, string numeroConta, Cliente cliente) : this(numeroBanco, numeroAgencia, numeroConta)
        {
            this.ClienteInfo = cliente;
        }
        public ContaEspecial(int numeroBanco, string numeroAgencia, string numeroConta, Cliente cliente, double limite) : this(numeroBanco, numeroAgencia, numeroConta)
        {
            this.ClienteInfo = cliente;
            this.Limite = limite;
        }

        //métodos sobrescritos
        public async override void EfetuarOperacao(double valor, Operacoes operacao = Operacoes.Deposito)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor deve ser positivo");
            }
            switch (operacao)
            {
                case Operacoes.Deposito:
                    this.Saldo += valor;
                    break;
                case Operacoes.Saque:
                    if (valor > (this.Saldo + this.Limite))
                    {
                        throw new InvalidOperationException("Saldo insuficiente");
                    }
                    this.Saldo -= valor;
                    break;
            }
            await base.RegistrarMovimento(valor, operacao);
        }
        public override string Exibir()
        {
            return $"{base.Exibir()}\nLimite: {this.Limite}\nSalto Disponível: {this.Saldo + this.Limite}";
        }
        public override string MostrarExtrato()
        {
            return new StringBuilder(base.MostrarExtrato())
                        .Append($"\nLimite: {this.Limite:c}")
                        .Append($"\nSaldo Disponível: {this.Limite + this.Saldo:C2}")
                        .ToString();
    }
}
}
