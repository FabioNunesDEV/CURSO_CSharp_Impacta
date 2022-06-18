using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fornecer um valor real: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            double resultado = Math.Pow(valor, 2);
            Console.WriteLine($"O valor de {valor} ao quadrado é {resultado}");

            Console.ReadKey();
        }
    }
}
