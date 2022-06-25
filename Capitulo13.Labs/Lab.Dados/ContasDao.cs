using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Lab.Models;

namespace Lab.Dados
{
    public class ContasDao : Dao<Conta, string>
    {
        public override Conta Buscar(string chave)
        {
            throw new NotImplementedException();
        }

        public override int Incluir(Conta item)
        {
            var registros = 0;
            double limite = 0;
            if (item is ContaEspecial)
            {
                limite = ((ContaEspecial)item).Limite;
            }
            try
            {
                registros = cn.Execute("INSERT INTO TBContas (" +
                "NumeroDocumento, NumeroBanco, NumeroAgencia, " +
                "NumeroConta, Limite) " +
                "VALUES (@NumeroDocumento, @NumeroBanco, " +
                "@NumeroAgencia, @NumeroConta, @Limite)",
                new
                {
                    item.NumeroDocumento,
                    item.NumeroBanco,
                    item.NumeroAgencia,
                    item.NumeroConta,
                    Limite = limite
                });
            }
            catch
            {
                throw;
            }
            return registros;
        }

        public override IEnumerable<Conta> Listar(string chave = null)
        {
            List<Conta> contas = new List<Conta>();
            try
            {
                var lista = cn.Query<ContaEspecial>("SELECT * from TBContas");

                //separando os clientes por PF e PJ
                foreach (var item in lista)
                {
                    if (item.Limite == 0) //Conta Comum
                    {
                        var cc = new ContaCorrente(item.NumeroBanco,
                        item.NumeroAgencia, item.NumeroConta);
                        cc.Id = item.Id;
                        cc.NumeroDocumento = item.NumeroDocumento;
                        contas.Add(cc);
                    }
                    else
                    {
                        contas.Add(item);
                    }
                }
            }
            catch 
            {
                throw;
            }

            return contas;
        }

        public override int Remover(Conta item)
        {
            throw new NotImplementedException();
        }
    }
}
