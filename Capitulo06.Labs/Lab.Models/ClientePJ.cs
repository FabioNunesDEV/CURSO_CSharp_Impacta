using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interfaces;
using Lab.Utilitarios;

namespace Lab.Models
{
    public class ClientePJ: Cliente, IDocumento
    {
        //propriedade implementada da interface
        private string _cpf;
        public string NumeroDocumento
        {
            get => _cpf;
            set => _cpf = (value.ValidarCNPJ() ? value :
            throw new Exception("CNPJ Inválido"));
        }
        //método implementado da interface
        public string MostrarDocumento()
        {
            return $"CNPJ do cliente: {NumeroDocumento}";
        }
        //construtores
        public ClientePJ(string Cpf, string Nome, Sexos Sexo)
        : base(Nome, Sexo)
        {
            this.NumeroDocumento = Cpf;
        }
        public ClientePJ(string Cpf, string Nome, Sexos Sexo, int Idade, Endereco endereco)
        : base(Nome, Sexo, Idade)
        {
            this.NumeroDocumento = Cpf;
            base.EnderecoResidencial = endereco;
        }
        public override string Exibir()
        {
            return $"{MostrarDocumento()}\n" +
            $"{base.Exibir()}";
        }
    }
}
