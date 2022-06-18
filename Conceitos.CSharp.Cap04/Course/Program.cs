using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex02();            
        }

        static void Ex01()
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = "Abigail",
                Idade = 20,
                Peso = 65,
                Altura = 1.70
            };

            Console.WriteLine(pessoa.GetPessoa());
            Console.ReadKey();
        }

        static void Ex02()
        {
            Pessoa pessoa = new Pessoa("Abigail", 20, 65, 1.70);

            Console.WriteLine(pessoa.GetPessoa());
            Console.ReadKey();
        }
    }
}
