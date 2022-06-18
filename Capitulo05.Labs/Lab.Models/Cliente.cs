using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Utilitarios;

namespace Lab.Models
{
    public class Cliente
    {
        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => _cpf = (value.ValidarCPF() ? value :
            throw new Exception("CPF inválido"));
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }
        public ContaCorrente Conta { get; set; }

        public Cliente(string cpf, string nome, Sexos sexo)
        {
            Cpf = cpf;
            Nome = nome;
            Sexo = sexo;
        }

        public Cliente(string cpf, string nome, Sexos sexo, Endereco enderecoResidencial) : this(cpf, nome, sexo)
        {
            EnderecoResidencial = enderecoResidencial;
        }

        public Cliente(string Cpf, string Nome, Sexos Sexo, int idade) : this(Cpf, Nome, Sexo)
        {
            this.Idade = Idade;
        }

        ~Cliente()
        {
            if (this.Conta != null)
            {
                this.Conta = null;
            }
        }

        public string Exibir()
        {
            return $"Cpf: {this._cpf}\n" +
            $"Nome: {this.Nome}\n" +
            $"Idade: {this.Idade}\n" +
            $"Sexo: {this.Sexo}\n" +
            $"ENDEREÇO DO CLIENTE:\n" +
            $"{this.EnderecoResidencial.Exibir()}";
        }
    }
}