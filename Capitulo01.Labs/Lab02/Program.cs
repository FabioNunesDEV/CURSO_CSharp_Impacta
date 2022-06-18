using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o salário do funcionário: ");
            double salario = Convert.ToDouble(Console.ReadLine(),CultureInfo.InvariantCulture);

            // Cáculo de 10% sobre o salário fornecido.
            double desconto = salario * 10 / 100;
            double salarioLiquido = salario - desconto;

            string resposta = $"Funcionario: {nome}\nSalário Bruto: {salario:C}\nDesconto: {desconto:c}\nSalário Líquido: {salarioLiquido:c2}";

            Console.WriteLine(resposta);

            Console.ReadKey();

        }
    }
}
