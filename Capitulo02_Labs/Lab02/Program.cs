using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe a quantidade de digítos da senha: ");
            int digitos = Int32.Parse(Console.ReadLine());

            if (digitos<4 || digitos >10 || digitos % 2 != 0)
            {
                Console.WriteLine($"O valor {digitos} é inválido de acordo com as regras.");
                Console.ReadKey();
                return;
            }

            string senha = "";
            Random rnd = new Random();

            for (int i = 0; i < digitos; i++)
            {
                int numero = rnd.Next(0, 9);

                senha += numero;
            }

            Console.WriteLine($"Senha gerada: {senha}");
            Console.ReadKey();
        }
    }
}
