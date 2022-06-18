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

        public Conta (int banco, string agencia, string conta)
        {
            this.NumeroBanco = banco;
            this.NumeroAgencia = agencia;
            this.NumeroConta = conta;
        }

        public abstract string MostrarExtrato(); 
    }
}
