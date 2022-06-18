using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public abstract class Figura
    {
        public string Exibir()
        {
            string nomeClasse = this.GetType().Name;
            double area = this.CalcularArea();

            return $"Classe: {nomeClasse}\nÁrea: {area}";
        }

        public abstract double CalcularArea();
    }
}
