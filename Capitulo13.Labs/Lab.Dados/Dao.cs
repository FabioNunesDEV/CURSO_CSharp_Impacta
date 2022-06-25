using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Models;

namespace Lab.Dados
{
    public abstract class Dao <T,K> where T: class
    {
        protected string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Users\fabio\Documents\CURSO EXERCICIOS\CURSO_CSharp_Impacta\Capitulo13.Labs\Lab.Dados\DBAplicacaoBancaria.mdf;Integrated Security=True";

        protected SqlConnection cn;

        public Dao()
        {
            cn = new SqlConnection(conexao);
        }

        public abstract int Incluir(T item);
        public abstract T Buscar(K chave);
        public abstract IEnumerable<T> Listar(K chave = default(K));
        public abstract int Remover(T item);
    }
}
