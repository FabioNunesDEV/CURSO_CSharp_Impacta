using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Biblia : Livros
    {
        public int Capitulos { get; set; }

        public override string ExibirDados()
        {
            return base.ExibirDados() + "\nCapitulos: " + Capitulos;
        }
    }
}
