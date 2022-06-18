using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Circulo : Figura
    {
        public Circulo()
        {
        }

        public Circulo(double raio)
        {
            this.Raio = raio;
        }

        public double Raio { get; set; }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(this.Raio, 2);
        }
    }
}
