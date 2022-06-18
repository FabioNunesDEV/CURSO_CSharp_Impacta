using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class AutomovelLuxo:Automovel
    {
        public new string Fabricante = "Mercedez-Benz";
        public string ExibirExemplo()
        {
            return
            "Fabricante superclasse: " + base.Fabricante +
            "\nFabricante subclasse: " + this.Fabricante;
        }
    }
}
