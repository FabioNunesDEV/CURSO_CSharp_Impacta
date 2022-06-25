using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int NumeroBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public string NumeroDocumento { get; set; }
        public List<Movimento> Movimentos { get; set; }
        public Cliente ClienteInfo { get; set; }
        public Conta()
        {
            this.Movimentos = new List<Movimento>();
        }
        public Conta(int numeroBanco, string numeroAgencia, string numeroConta)
        {
            if (this.Movimentos == null)
            {
                this.Movimentos = new List<Movimento>();
            }
            this.NumeroBanco = numeroBanco;
            this.NumeroAgencia = numeroAgencia;
            this.NumeroConta = numeroConta;
        }

        protected async Task RegistrarMovimento(double valor, Operacoes operacao)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor deve ser positivo");
            }

            this.Movimentos.Add(new Movimento()
            {
                Data = DateTime.Now,
                Historico = operacao == Operacoes.Saque ? "SAQUE":"DEPÓSITO",
                Operacao = operacao,
                Valor = valor
            });
        }

        public virtual string MostrarExtrato()
        {
            throw new Exception("Este método deve ser implementado");
        }

        public virtual void EfetuarOperacao(double valor, Operacoes opercao = Operacoes.Deposito) { }

        public override string ToString()
        {
            return this.NumeroAgencia + "/" + this.NumeroConta;
        }
    }
}
