using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            int tentativas=6;

            Console.Clear();

            Console.WriteLine("Jogo da Adivinhação");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine("Tente adivinhar o número entre 0 e 100 selecionado.");
            Console.WriteLine($"Você tem: {tentativas} tentativas");

            int numero = new Random().Next(0, 100);
            int i;
            for (i = 1; i<=tentativas; i++)
            {
                Console.WriteLine();

                Console.Write($"{i}º tentativa. Digite um número entre 0 e 100: ");
                int palpite = Int32.Parse(Console.ReadLine());

                Console.WriteLine();

                if (palpite < 0 || palpite > 100)
                {
                    Console.WriteLine($"O número {palpite} não é válido ! Tente novamente.");
                }
                else
                {
                    if (numero < palpite)
                    {
                        Console.WriteLine($"O número sorteado é menor que {palpite} ! Tente novamente.");
                    }
                    else if (numero > palpite)
                    {
                        Console.WriteLine($"O número sorteado é maior que {palpite} ! Tente novamente.");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();

            if (i==tentativas+1)
            {
                Console.WriteLine($"O número sorteado foi {numero}. Você perdeu.");               
            }
            else
            {
                Console.WriteLine($"O número sorteado foi {numero}. Parabéns você ganhou.");
            }

            Console.ReadKey();
        }
    }
}
