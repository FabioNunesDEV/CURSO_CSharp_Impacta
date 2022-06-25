using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Lab.Models;

namespace Lab.Dados
{
    public class ClientesDao : Dao<Cliente, string>
    {
        public override Cliente Buscar(string chave)
        {
            Cliente cliente = null;
            try
            {
                cliente = cn.QueryFirst<Cliente>(
                "SELECT NumeroDocumento, " +
                "Nome, Idade," +
                "case Sexo" +
                " when 'F' then 1" +
                " when 'M' then 0 " +
                "end as Sexo from TBClientes WHERE " +
                "NumeroDocumento = @NumeroDocumento",
                new { NumeroDocumento = chave });
            }
            catch
            {
                throw;
            }
            return cliente;
        }

        public override int Incluir(Cliente item)
        {
            var registros = 0;
            try
            {
                string documento;
                if (item is ClientePF)
                {
                    documento = ((ClientePF)item).NumeroDocumento;
                }
                else
                {
                    documento = ((ClientePJ)item).NumeroDocumento;
                }
                registros = cn.Execute("INSERT INTO TBClientes (NumeroDocumento, Nome, Idade, Sexo) VALUES (@NumeroDocumento, @Nome, @Idade, @Sexo)",
                                            new
                                            {
                                                NumeroDocumento = documento,
                                                item.Nome,
                                                item.Idade,
                                                Sexo = (item.Sexo == Sexos.Masculino ? 'M' : 'F')
                                            });
                var endereco = cn.Execute("INSERT INTO TBEnderecos (NumeroDocumento,Logradouro,Numero,Cidade,Cep) VALUES (@NumeroDocumento,@Logradouro,@Numero,@Cidade, @Cep)",
                                            new
                                            {
                                                NumeroDocumento = documento,
                                                item.EnderecoResidencial.Logradouro,
                                                item.EnderecoResidencial.Numero,
                                                item.EnderecoResidencial.Cidade,
                                                item.EnderecoResidencial.Cep
                                            });
            }
            catch
            {
                throw;
            }
            return registros;
        }

        public override IEnumerable<Cliente> Listar(string chave = null)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                var lista = cn.Query<Cliente>("SELECT NumeroDocumento,Nome, Idade,case Sexo when 'F' then 1 when 'M' then 0 end as Sexo from TBClientes");            

                //separando os clientes por PF e PJ
                foreach (var item in lista)
                {
                    var endereco = BuscarEndereco(item.NumeroDocumento);
                    if (item.NumeroDocumento.Length == 11)
                    {
                        clientes.Add(new ClientePF(item.NumeroDocumento,
                        item.Nome, item.Sexo, item.Idade, endereco));
                    }
                    else
                    {
                        clientes.Add(new ClientePJ(item.NumeroDocumento,
                        item.Nome, item.Sexo, item.Idade, endereco));
                    }
                }
            }
            catch
            {
            throw;
            }
            return clientes;
        }
        private Endereco BuscarEndereco(string documento)
        {
            Endereco endereco;
            try
            {
                endereco = cn.QueryFirst<Endereco>(
                "SELECT * FROM TBEnderecos WHERE " +
                "NumeroDocumento = @NUmeroDocumento",
                new { NumeroDocumento = documento });
            }
            catch
            {
                throw;
            }
            return endereco;
        }

        public override int Remover(Cliente item)
        {
            string documento;
            var registros = 0;
            if (item is ClientePF)
            {
                documento = ((ClientePF)item).NumeroDocumento;
            }
            else
            {
                documento = ((ClientePJ)item).NumeroDocumento;
            }

            try
            {
                registros = cn.Execute("DELETE FROM TBClientes WHERE NumeroDocumento = @NumeroDocumento", new {NumeroDocumento = documento});
            }
            catch 
            {
                throw;
            }

            return registros;
        }
    }
}
