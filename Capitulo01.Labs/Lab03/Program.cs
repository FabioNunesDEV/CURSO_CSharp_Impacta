using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o salário do funcionário: ");
            double salario = Convert.ToDouble(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.Write("Informe o valor gasto com transporte: ");
            double transporte = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            double valeTransporte = salario * 6 / 100;

            double valeTransporteReal = transporte > valeTransporte ? valeTransporte : transporte;

            string resultado = $"\nFuncionário: {nome}\nSalário: {salario}\nDesconto VT: {valeTransporteReal}";

            Console.WriteLine(resultado);

            Console.ReadKey();
        }
    }
}
