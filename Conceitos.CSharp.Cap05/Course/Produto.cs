using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        // Concede a permissão de sobrescrita
        public virtual string ExibirDados()
        {
            return string.Format("Nome: {0}\nPreço: {1}", Nome.ToLower(), Preco.ToString("C2"));
        }
    }
}
