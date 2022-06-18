using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Produto prod = new Produto();
            prod.Nome = "Jatoba";
            prod.Preco = 6.47m;

            Console.WriteLine("PRODUTO\n" + prod.ExibirDados());

            //----------------------------------

            Livros gibi = new Livros();
            gibi.Nome = "Soldado Invernal - Marcha da Amargura";
            gibi.Preco = 19.90m;
            gibi.NPaginas = 128;

            Console.WriteLine("LIVRO\n" + gibi.ExibirDados());

            Console.ReadKey();
        }

        static void Ex02()
        {
            Figura fig1 = new Retangulo() { Base = 2, Altura = 3 };
            Figura fig2 = new Retangulo(2,3); 
           
            Figura fig3 = new Circulo() { Raio = 5 };
            Figura fig4 = new Circulo(5);

            Console.WriteLine(fig1.Exibir());
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(fig2.Exibir());
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(fig3.Exibir());
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(fig4.Exibir());
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex03()
        {
            AutomovelLuxo carro = new AutomovelLuxo();
            Console.WriteLine(carro.ExibirExemplo());
            Console.ReadKey();
        }

        static void Ex04()
        {
            Biblia biblia = new Biblia();

            biblia.Nome = "Biblia sagrada.";
            biblia.Preco = 100.00m;
            biblia.NPaginas = short.MaxValue;
            biblia.Capitulos = 50;

            Console.WriteLine(biblia.ExibirDados());

            Console.ReadKey();
        }
    }
}
