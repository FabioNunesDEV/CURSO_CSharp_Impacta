using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Retangulo : Figura
    {
        public Retangulo()
        {
        }

        public Retangulo(double @base, double altura)
        {
            this.Base = @base;
            this.Altura = altura;
        }

        public double Base { get; set; }
        public double Altura { get; set; }
        public override double CalcularArea()
        {
            return this.Base * this.Altura;
        }
    }
}
