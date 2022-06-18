using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Utilitarios;

namespace Lab.Models
{
    public abstract class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }
        public ContaCorrente Conta { get; set; }

        public Cliente(string nome, Sexos sexo)
        {
            Nome = nome;
            Sexo = sexo;
        }
        public Cliente(string Nome, Sexos Sexo, int idade) : this(Nome, Sexo)
        {
            this.Idade = idade;
        }
        public Cliente(string nome, Sexos sexo, Endereco enderecoResidencial) : this(nome, sexo)
        {
            EnderecoResidencial = enderecoResidencial;
        }
        ~Cliente()
        {
            if (this.Conta != null)
            {
                this.Conta = null;
            }
        }

        public virtual string Exibir()
        {
            return $"Nome: {this.Nome}\n" +
            $"Idade: {this.Idade}\n" +
            $"Sexo: {this.Sexo}\n" +
            $"ENDEREÇO DO CLIENTE:\n" +
            $"{this.EnderecoResidencial.Exibir()}";
        }
    }
}