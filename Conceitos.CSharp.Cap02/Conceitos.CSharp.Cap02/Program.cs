using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.CSharp.Cap02
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex12();
        }

        enum Periodo
        {
            M, T, N
        }

        // Exemplo de IF/ ELSE
        static void Ex01()
        {
            // Definir as variaveis
            int a;
            int b;
            //---------------------

            Console.WriteLine("Exemplo if 1");

            // Inicializando as variaveis
            a = 20;
            b = 100;

            // if para verificar a veracidade de expressão
            if (a < b)
            {
                Console.WriteLine($"{a} é menor do que {b}");
            }
            Console.WriteLine(new string('-', 30));
            //---------------------

            Console.WriteLine("Exemplo if 2");

            a = 20;
            b = 10;

            // Como a condição é falsa , o texto não será exibido
            if (a < b)
            {
                Console.WriteLine($"{a} é menor que {b}");
            }
            Console.WriteLine(new string('-', 30));
            //---------------------

            Console.WriteLine("Exemplo if 3");
            a = 20;
            b = 10;

            // Como a condição é falsa, será exibido o texto do else
            if (a < b)
            {
                Console.WriteLine($"{a} é menor que {b}");
            }
            else
            {
                Console.WriteLine($"{a} é maior que {b}");
            }
            Console.WriteLine(new string('-', 30));
            //---------------------

            Console.WriteLine("Exemplo if 4 - com erro");
            a = 20;
            b = 20;

            // Como a condição é falsa, será exibido o texto do else
            // que nesse caso, será um erro.
            if (a < b)
            {
                Console.WriteLine($"{a} é menor que {b}");
            }
            else
            {
                Console.WriteLine($"{a} é maior que {b}");
            }
            Console.WriteLine(new string('-', 30));
            //---------------------

            Console.WriteLine("Exemplo if 4 - corrigido");
            Console.Write("Informe um valor inteiro A: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe um valor inteiro B: ");
            b = Convert.ToInt32(Console.ReadLine());

            // Como a condição é falsa, será exibido o texto do else
            // que nesse caso, será um erro.
            if (a < b)
            {
                Console.WriteLine($"{a} é menor que {b}");
            }
            else if (a > b)
            {
                Console.WriteLine($"{a} é maior que {b}");
            }
            else
            {
                Console.WriteLine($"{a} é igual a {b}");
            }
            Console.WriteLine(new string('-', 30));
            //---------------------

            Console.ReadKey();
        }

        // Exemplo Switch/Case.
        static void Ex02()
        {
            // Definir variaveis
            Console.WriteLine("Informe um valor de 1 a 7:");
            string diaSemana = Console.ReadLine();
            string resultado = "";

            // Verificar a existência de algum valor para a variável diaSemana.
            if (diaSemana.Trim() == "")
            {
                return;
            }

            // Utilizar a instrução switch

            switch (diaSemana)
            {
                case "1":
                    resultado = "Domingo";
                    break;
                case "2":
                    resultado = "Segunda-feira";
                    break;
                case "3":
                    resultado = "Terça-feira";
                    break;
                case "4":
                    resultado = "Quarta-feira";
                    break;
                case "5":
                    resultado = "Quinta-feira";
                    break;
                case "6":
                    resultado = "Sexta-feira";
                    break;
                case "7":
                    resultado = "Sábado";
                    break;
                default:
                    resultado = $"Valor {diaSemana} não é um número válido para dia da semana.";
                    break;
            }

            Console.WriteLine(resultado);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();

        }

        // Exemplo Switch/Case mais de uma opção mesmo resultado.
        static void Ex03()
        {
            // Definir variaveis
            Console.WriteLine("Informe um valor de 1 a 7:");
            string diaSemana = Console.ReadLine();
            string resultado = "";

            // Verificar a existência de algum valor para a variável diaSemana.
            if (diaSemana.Trim() == "")
            {
                return;
            }

            // Utilizar a instrução switch

            switch (diaSemana)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    resultado = "Dia util";
                    break;
                case "1":
                case "7":
                    resultado = "Final de semana";
                    break;
                default:
                    resultado = $"Valor {diaSemana} não é um número válido para dia da semana.";
                    break;
            }

            Console.WriteLine(resultado);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();

        }

        // Exemplo Switch-Expression.
        static void Ex04()
        {
            Periodo periodo = Periodo.M;
            string descricao;

            _ = (periodo switch
            {
                Periodo.M => descricao = "Manhã",
                Periodo.T => descricao = "Tarde",
                Periodo.N => descricao = "Noite",
                _ => descricao = "Periodo inválido"
            });

            Console.WriteLine("Periodo informado: " + descricao);
            Console.ReadLine();
        }

        // Exemplo Switch-Expression.
        static void Ex04b()
        {
            Periodo periodo = Periodo.M;
            string descricao;

            descricao = (periodo switch
            {
                Periodo.M => "Manha",
                Periodo.T  => "Tarde",
                Periodo.N => "Noite",
                _ => "Periodo inválido"
            });

            Console.WriteLine("Periodo informado: " + descricao);
            Console.ReadLine();
        }

        // Exemplo Switch-Expression com método.
        static string Ex05a(Periodo periodo) =>
            periodo switch
            {
                Periodo.M => "Manhã",
                Periodo.T => "Tarde",
                Periodo.N => "Noite",
                _ => "Periodo inválido"
            };

        // Exemplo Switch-Expression com método - Chamada.
        static void Ex05b()
        {
            Console.WriteLine("Periodo informado: " + Ex05a(Periodo.M));

            Console.ReadKey();
        }

        // Exemplo While
        static void Ex06()
        {
            int num = 1000;

            // Enquanto num for menor ou igual a 5000
            while (num <= 5000)
            {
                Console.WriteLine("Num: " + num);
                num += 1000;
            }

            Console.WriteLine(new string('-', 30));

            Console.ReadLine();
        }

        // Exemplo Do/While.
        static void Ex07()
        {
            int num = 8000;

            // bloco de instruções será executado uma vez

            do
            {
                Console.WriteLine("Num: " + num);
                num += 1000;

            } while (num <= 5000); // Enquanto num for menor ou igual a 5000

            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        // Exemplo FOR.
        static void Ex08()
        {
            for (int a = 1, b = 1; (a < 300 && b < 300); a *= 2, b *= 2)
            {
                Console.WriteLine("Valor a: " + a);
                Console.WriteLine("Valor b: " + b);
                Console.WriteLine(new string('-', 30));
            }

            Console.ReadKey();
        }

        // Exemplo FOR / Break
        static void Ex09()
        {
            for (int a = 1; a <= 1000; a++)
            {
                if (a > 20) break;
                Console.WriteLine("Valor de a: " + a);
            }

            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        // Exemplo FOR / Continue.
        static void Ex10()
        {
            for (int a = 0; a < 20; a++)
            {
                if (a == 5 || a == 10) continue;

                Console.WriteLine("Valor de a: " + a);
            }
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex11()
        {
            string[] lista = { "Brasil", "Alemanha", "México", "Chile", "Holanda", "Colômbia", "Argentina", "Uruguai" };

            foreach (string pais in lista)
            {
                // Paises que começam com a letra C
                if (pais.ToUpper().StartsWith("C"))
                {
                    Console.WriteLine(pais.ToUpper());                    
                };

                          
            }
            Console.WriteLine(new string('-', 30));
            Console.ReadKey();
        }

        static void Ex12()
        {
            string texto = "";
            for (int n = 0; n < 10; n += 2)
            {
                texto += n.ToString("00");
            }
            Console.WriteLine(texto);

            Console.ReadKey();
        }
    }
}
