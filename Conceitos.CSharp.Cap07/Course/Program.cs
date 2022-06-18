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
            PilhaGenerica<string> pilhaString = new PilhaGenerica<string>();
            pilhaString.Push("Osvaldo");
            pilhaString.Push("Jesse");
            pilhaString.Push("Abigail");

            int itens = pilhaString.Count();
            Console.WriteLine(itens.ToString());

            Console.WriteLine("Elemento no topo (pilhaString): " + pilhaString.Pop());

            PilhaGenerica<int> pilhaInt = new PilhaGenerica<int>();
            pilhaInt.Push(122);
            pilhaInt.Push(2956);
            pilhaInt.Push(365);

            Console.WriteLine("Elemento no topo (pilhaInt): " + pilhaInt.Pop());

            Console.ReadKey();
        }
    }
}
