using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex04();
        }

        static void Ex01()
        {
            Task t1 = new Task(new Action(MostrarHora));
            t1.Start();

            Console.WriteLine("Fez");

            Console.ReadKey();
        }

        static void Ex02()
        {
            Task t1 = new Task(new Action(MostrarPontos));

            t1.Start();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("*");
                System.Threading.Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        static void Ex03()
        {
            Task t3 = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
            });

            t3.Wait();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("*");
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        static void Ex04()
        {
            Task[] tasks = new Task[3]
            {
                Task.Run(()=>Funcao1()),
                Task.Run(()=>Funcao2()),
                Task.Run(()=>Funcao3())
            };

            Task.WaitAll(tasks);

            Console.WriteLine("Fim da execução");

            Console.ReadKey();
        }

        static void Ex05()
        {
            Task<int> t4 = Task.Run<int>(() =>
            {
                int cont = 0;
                for (int i = 0; i < 20; i++)
                {
                    cont += 1;
                    Thread.Sleep(100);
                }
                return cont;
            });

            Console.WriteLine("teste1");

            Console.WriteLine("Resultado: " + t4.Result);

            Console.WriteLine("teste2");

            Console.ReadKey();
        }

        static void Ex06()
        {
            var lista = ListaNomes().Result;
            int x = 1;
            foreach (var item in lista)
            {
                Console.WriteLine($"Nome na posição {x++}:" + item);
            }

            Console.ReadKey();
        }

        private static async Task<IEnumerable<string>> ListaNomes()
        {
            var nomes = new List<string>()
            {
                "Gabi", "Mônica", "Junior", "Peter"
            };

            foreach (var item in nomes)
            {
                if (item.Contains("a"))
                {
                    Console.WriteLine(item);
                    await Task.Delay(200);
                }
            }
            return nomes;
        }

        private static void Funcao1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Tarefa 1");
        }

        private static void Funcao2()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Tarefa 2");
        }

        private static void Funcao3()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Tarefa 3");
        }

        private static void MostrarHora()
        {
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine($"Hora atual: {DateTime.Now:t}");
        }

        private static void MostrarPontos()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");

                System.Threading.Thread.Sleep(500);

            }
        }
    }
}
