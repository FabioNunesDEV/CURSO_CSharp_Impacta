using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
