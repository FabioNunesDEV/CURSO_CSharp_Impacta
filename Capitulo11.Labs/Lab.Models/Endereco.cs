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
        public Endereco(string logradouro, int numero, string cidade, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
        }

        public string Exibir()
        {
            return $"Logradouro: {this.Logradouro}\nNúmero: {this.Numero}\nCidade: {this.Cidade}\nCEP: {this.Cep}";
        }
    }
}
