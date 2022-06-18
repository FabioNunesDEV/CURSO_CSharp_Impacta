using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public delegate void Mensagem();

    public delegate bool Buscar<T>(T item);
    class Program
    {
        static void Main(string[] args)
        {
            Ex05();

            Console.ReadKey();
        }

        static void Ex01()
        {
            Mensagem msg1 = new Mensagem(ExibirMensagem01);
            msg1();
        }

        static void Ex02()
        {
            Mensagem msg1 = null;
            msg1 += ExibirMensagem01;
            msg1 += ExibirMensagem02;
            msg1();
        }
        static void Ex03()
        {
            Mensagem msg1 = () => Console.WriteLine("Uso de espressão lambda");
            msg1();

            //Mensagem msg2 = () =>
        }

        static void Ex04()
        {
            string[] cidades = { "Lorena", "Saquarems", "Paraty", "Salvador" };

            Buscar<string> busca1 = p => p.Contains("o");

            foreach (var item in cidades)
            {
                if (busca1(item))
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }

        static void Ex05()
        {
            List<string> cidades = new List<string>() { "Lorena", "Saquarems", "Paraty", "Salvador", "Luis Pessoa" };

            var cidade = cidades.Find(x => x.StartsWith("L"));

            Console.WriteLine(cidade);

            Console.ReadKey();
        }

        private static void ExibirMensagem01()
        {
            Console.WriteLine("Primeira Mensagem");
        }

        private static void ExibirMensagem02()
        {
            Console.WriteLine("Segunda Mensagem");
        }

    }
}
