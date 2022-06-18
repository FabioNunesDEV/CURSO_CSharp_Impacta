using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public struct Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }

        public string Exibir()
        {
            return $"Logradouro: {this.Logradouro}\nNúmero: {this.Numero}\nCidade: {this.Cidade}\nCEP: {this.Cep}";
        }
    }
}
