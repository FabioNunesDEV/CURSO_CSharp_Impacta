using Dapper;
using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Dados
{
    public class MovimentoDao:Dao<Movimento, int>
    {
        
        public override Movimento Buscar (int chave)
        {
            throw new NotImplementedException();
        }

        public override int Incluir (Movimento item)
        {
            var registros = 0;

            try
            {
                int teste = ((int)item.Operacao);

                //registra um novo movimento
                registros = cn.Execute("INSERT INTO TBMovimentos (" +
                "IdConta, Data, Historico, Valor, Operacao) " +
                "VALUES (" +
                "@IdConta, @Data, @Historico, @Valor, @Operacao)",
                new
                {
                    item.IdConta,
                    item.Data,
                    item.Historico,
                    item.Valor,
                    Operacao = (int)item.Operacao
                });
                //verifica se o movimento já foi realizado. Neste caso, a
                //tabela TBSaldos já possui um registro.
                var saldo = cn.QueryFirstOrDefault<ValorSaldo>("SELECT * FROM TBSaldos WHERE IdConta=@IdConta", new { item.IdConta });
                if (saldo == null)
                {
                    //SE não existir, ela é criada com o valor do saldo
                    cn.Execute("INSERT INTO TBSaldos (IdConta,Saldo) VALUES (@IdConta,@Saldo) ", new
                    {
                        item.IdConta,
                        Saldo = item.Valor
                    });
                }
                else
                {
                    //caso contrário, o saldo é atualizado
                    var saldoAtual = (item.Operacao == Operacoes.Deposito)
                    ?
                    saldo.Saldo + item.Valor : saldo.Saldo - item.
                    Valor;
                    cn.Execute("UPDATE TBSaldos SET Saldo=@Saldo WHERE IdConta = @IdConta", new {item.IdConta,Saldo = saldoAtual });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return registros;
        }

        public override IEnumerable<Movimento> Listar (int chave =0)
        {
            IEnumerable<Movimento> movimentos = new List<Movimento>();

            try
            {
                movimentos = cn.Query<Movimento>("SELECT * FROM TBMovimentos WHERE IdConta=@IdConta",new { IdConta = chave });
            }
            catch 
            {
                throw;
            }

            return movimentos;
        }
        public override int Remover(Movimento item)
        {
            throw new NotImplementedException();
        }
    }

}
