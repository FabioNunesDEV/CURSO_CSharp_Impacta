using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public abstract class Conta
    {
        public int NumeroBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public List<Movimento> Movimentos { get; set; }
        public Cliente ClienteInfo { get; set; }

        public Conta(int banco, string agencia, string conta)
        {
            if (this.Movimentos == null)
            {
                this.Movimentos = new List<Movimento>();
            }
            this.NumeroBanco = banco;
            this.NumeroAgencia = agencia;
            this.NumeroConta = conta;
        }

        protected void RegistrarMovimento(double valor, Operacoes operacao)
        {
            this.Movimentos.Add(new Movimento()
            {
                Data = DateTime.Now,
                Historico = operacao == Operacoes.Saque ? "SAQUE":"DEPÓSITO",
                Operacao = operacao,
                Valor = valor
            });
        }

        public abstract string MostrarExtrato();

        public abstract void EfetuarOperacao(double valor, Operacoes opercao = Operacoes.Deposito);

        public override string ToString()
        {
            return this.NumeroAgencia + "/" + this.NumeroConta;
        }
    }
}
