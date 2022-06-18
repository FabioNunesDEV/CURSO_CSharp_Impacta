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
            Console.Write("Qual é seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Qual é sua idade: ");
            int idade = Int32.Parse(Console.ReadLine());

            double valorIngresso = 0;
            if (idade<=17)
            {
                valorIngresso = 40d;
            }else if(idade <= 59){

                valorIngresso = 50d;
            }else
            {
                valorIngresso = 20d;
            }

            string resposta = $"O convidado {nome} tem {idade} " +$"anos, e pagará {valorIngresso:c}";
            Console.WriteLine(resposta);
            Console.ReadKey();
        }
    }
}
