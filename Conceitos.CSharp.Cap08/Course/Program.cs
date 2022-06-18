using System;
using System.Collections;
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
            Ex14();
        }

        static void Ex01()
        {
            int[] numeros = new int[] { 0, 50, 100, 150, 200, 250, 200, 450, 500 };

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine($"Números[{i}] = {numeros[i]}");
            }

            Console.ReadKey();
        }

        static void Ex02()
        {
            int[] numeros = new int[] { 0, 50, 100, 150, 200, 250, 200, 450, 500 };

            foreach (int i in numeros)
            {
                Console.WriteLine($"Números[{i}] = {i}");
            }

            Console.ReadKey();
        }

        static void Ex03()
        {
            int[,] numeros = new int[3, 5];

            Console.WriteLine("Total de elementos do array: " + numeros.Length);

            Console.ReadKey();
        }

        static void Ex04()
        {
            int[,,] triDimens = new int[2, 3, 4]
{
                {
                    {1,2,3,4 },
                    {4,3,2,1 },
                    {5,6,7,8 }
                },
                {
                    {1,2,3,4 },
                    {4,3,2,1 },
                    {5,6,7,8 }
                }
};
            Console.WriteLine($"Quantidade de dimensões: {triDimens.Rank}");
            Console.WriteLine($"Quantidade total de elementos: {triDimens.Length}");
            for (int i = 0; i < triDimens.Rank; i++)
            {
                Console.WriteLine($"Dimensão [{i + 1}] - elementos: {triDimens.GetLength(i)}");
            }

            for (int x = 0; x < triDimens.GetLength(0); x++)
            {
                for (int y = 0; y < triDimens.GetLength(1); y++)
                {
                    for (int z = 0; z < triDimens.GetLength(2); z++)
                    {
                        Console.WriteLine($"Elemento dimensão [{x},{y},{z}] = {triDimens[x,y,z]}" );
                    }
                }
            }


            Console.ReadKey();
        }

        static void Ex05()
        {
            decimal[] valores = { 15, 20, 25, 30, 80 };

            Console.WriteLine("Media: " + CalcularMedia(valores));

            Console.ReadKey();
        }

        static void Ex06()
        {

            Console.WriteLine("Media: " + CalcularMedia2(15,20,25));

            Console.ReadKey();
        }

        static void Ex07()
        {
            ExibirParamtros("jatobá", 12.5m, 'K', 23.1f, DateTime.Now);

            Console.ReadKey();
        }

        static void Ex08()
        {
            ArrayList lista = new ArrayList();

            lista.Add("régua");
            lista.Add("lápis");
            lista.Add("borracha");
            lista.Add("apontador");
            lista.Add("estojo");

            lista.Insert(2, "caderno");
            lista.Remove("apontador");
            lista.RemoveAt(1); 

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }

            int posicao = lista.IndexOf("borracha");
            Console.WriteLine("Borracha está na posição: " + (posicao+1));


            Console.WriteLine(new string('-', 30));
            Console.ReadKey();
        }

        static void Ex09()
        {
            Stack pilha = new Stack();

            pilha.Push("régua");
            pilha.Push("lápis");
            pilha.Push("borracha");
            pilha.Push("apontador");
            pilha.Push("estojo");

            foreach (object i in pilha)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Primeiro item da pilha antes de POP: " + pilha.Peek());
            Console.WriteLine(new string('-', 30));

            pilha.Pop();

            Console.WriteLine("Primeiro item da pilha depois do POP: " + pilha.Peek());
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex10()
        {
            Queue pilha = new Queue();

            pilha.Enqueue("régua");
            pilha.Enqueue("lápis");
            pilha.Enqueue("borracha");
            pilha.Enqueue("apontador");
            pilha.Enqueue("estojo");

            foreach (object i in pilha)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Primeiro item da pilha antes do Dequeue: " + pilha.Peek());
            Console.WriteLine(new string('-', 30));

            pilha.Dequeue();

            Console.WriteLine("Primeiro item da pilha depois do Dequeue: " + pilha.Peek());
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex11()
        {
            Hashtable dePara = new Hashtable();

            dePara.Add(1, "régua");
            dePara.Add(2, "lápis");
            dePara.Add(3, "apontador");
            dePara.Add(4, "borracha");
            dePara.Add(5, "estojo");

            foreach (DictionaryEntry i in dePara)
            {
                Console.WriteLine(i.Key + " - " + i.Value);
            }

            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex12()
        {
            List<Int32> listaInteiros = new List<Int32>();

            listaInteiros.Add(10);
            listaInteiros.Add(5);
            listaInteiros.Add(2);
            listaInteiros.Add(8);
            listaInteiros.Add(7);

            foreach (int item in listaInteiros)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));


            // Inicializadores de listas.

            List<string> lstNomes = new List<string>() { "Fábio", "Dani", "Barbara" };

            List<DateTime> lstDatas = new List<DateTime>() { new DateTime(2013, 2, 25), new DateTime(2013, 3, 30), new DateTime(2013, 4, 15) };

            Console.ReadKey();

        }

        static void Ex13()
        {
            HashSet<string> cursos = new HashSet<string>() 
            {
                "Java", "PHP", "Node.js", "Java", "SQL Server"
            };

            Console.WriteLine("Quant. Elementos em cursos: " + cursos.Count);

            foreach (var item in cursos)
            {
                Console.WriteLine(item);
            }

            SortedSet<string> nomes = new SortedSet<string>()
            {
                "Peter", "John", "Bruce", "Adam", "John", "Antony"
            };

            Console.WriteLine("\nQuant. Elementos em nomes: " + nomes.Count);

            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static void Ex14()
        {
            string[] texto = ListaNomesComA().ToArray();

            foreach (var item in texto)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static decimal CalcularMedia(decimal[] numeros)
        {
            decimal soma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                soma += numeros[i];
            }

            return soma / numeros.Length;
        }

        private static decimal CalcularMedia2(params decimal[] decimals)
        {
            decimal soma = 0;
            for (int i = 0; i < decimals.Length; i++)
            {
                soma += decimals[i];
            }

            return soma / decimals.Length;
        }

        private static void ExibirParamtros (params object[] valores)
        {
            foreach (object i in valores)
            {
                Console.WriteLine($"Valor: {i}");
                Console.WriteLine($"Tipo: {i.GetType().ToString()} ");
                Console.WriteLine(new string('-', 30));
            }
        }

        private static IEnumerable<string> ListaNomesComA()
        {
            string[] nomes = { "alice", "antonio", "erica", "luiz", "paulo", "ana paula" };

            foreach (var item in nomes)
            {
                if (item.StartsWith("a"))
                {
                    yield return item;
                }
            }
        }
    }
}
