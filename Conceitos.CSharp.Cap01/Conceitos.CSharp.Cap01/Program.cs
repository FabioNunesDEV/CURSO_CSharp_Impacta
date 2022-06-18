using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.CSharp.Cap01
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex15();
        }

        static void Ex01()
        {
            // Método responsavel por escrever uma linha no console.

            Console.BackgroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Conceitos do C#");

            Console.Beep();

            Console.ReadKey();            
        }

        static void Ex02()
        {
            //O valor 3 é atribuído à variável a
            int a = 3;

            //Exibe o valor de a
            Console.WriteLine("Valor de a: " + a.ToString());

            //O valor de a é atribuído à variável b
            int b = a;

            //Exibe o valor de b
            Console.WriteLine("Valor de b: " + b.ToString());

            //Variável a tem seu valor alterado para 5
            a = 5;

            //Exibe o novo valor de a
            Console.WriteLine("Novo valor de a: " +a.ToString());

            //Exibe o valor de b
            Console.WriteLine("Valor de b: " + b.ToString());

            Console.ReadKey();
        }

        static void Ex03()
        {
            //Declaração da variável
            int x = 5;

            //Exibe o valor x
            Console.WriteLine("Valor de x: " + x.ToString());

            //Novo valor de x
            //Equivale a x = x - 3
            x -= 3;

            //Exibe o valor x
            Console.WriteLine("Novo valor de x: " + x.ToString());

            Console.ReadKey();
        }

        static void Ex04()
        {
            int a;
            a = 5;
            Console.WriteLine("Exemplo Pré - Incremental");
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine("2 + ++a = " +(2 + ++a));
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine(new string('-', 50));
            a = 5;
            Console.WriteLine("Exemplo Pós - Incremental");
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine("2 + a++ = " + (2 + a++));
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine(new string('-', 50));
            a = 5;
            Console.WriteLine("Exemplo Pré - Decremental");
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine("2 + --a = " +(2 + --a));
            Console.WriteLine("valor de a: " +a);
            Console.WriteLine(new string('-', 50));
            a = 5;
            Console.WriteLine("Exemplo Pós - Decremental");
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine("2 + a-- = " + (2 + a--));
            Console.WriteLine("valor de a: " + a);
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }

        static void Ex05()
        {
            int a = 30, b = 40, c = 50, d = 60;
            Console.WriteLine("a: " +a);
            Console.WriteLine("b: " +b);
            Console.WriteLine("c: " +c);
            Console.WriteLine("d: " +d);
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("a < b || c == 50 --> " +(a < b || c == 50));
            Console.WriteLine("a < b || c == d  --> " +(a < b || c == d));
            Console.WriteLine("a > b || c == 50 --> " +(a > b || c == 50));
            Console.WriteLine("a > b || c == d  --> " +(a > b || c == d));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("a < b && c == 50 --> " +(a < b && c == 50));
            Console.WriteLine("a < b && c == d  --> " +(a < b && c == d));
            Console.WriteLine("a > b && c == 50 --> " +(a > b && c == 50));
            Console.WriteLine("a > b && c == d  --> " +(a > b && c == d));
            Console.WriteLine(new string('-', 20));
            Console.ReadKey();
        }

        static void Ex06()
        {
            int numero;
            numero = 10;
            Console.WriteLine(numero + " é " +(numero % 2 == 0 ? "par": "ímpar"));
            Console.WriteLine(new string('-', 20));
            numero = 15;
            Console.WriteLine(numero + " é " +(numero % 2 == 0 ? "par": "ímpar"));
            Console.WriteLine(new string('-', 20));
            Console.ReadKey();
        }

        static void Ex07()
        {
            string curso = null;
            string texto = curso ?? "Curso não informado";
            Console.WriteLine(texto);
            Console.ReadKey();
        }

        static void Ex08()
        {
            List<string> cursos = null;
            (cursos ??= new List<string>()).Add("C#");
            Console.WriteLine(string.Join(" ", cursos));
            Console.ReadKey();
        }

        static void Ex09()
        {
            string produto = "caneta";
            decimal preco = 6.32m;
            Console.WriteLine(string.Format("Produto: {0}\n\rPreço: {1}",produto, preco));
            Console.ReadKey();
        }

        static void Ex10()
        {
            string produto = "caneta";
            decimal preco = 6.32m;
            //Formato monetário com duas casas pós vírgula
            //Respeita as configurações regionais do Windows
            Console.WriteLine(string.Format("Produto: {0}\nPreço: {1:c2}",produto, preco));
            Console.ReadKey();
        }

        static void Ex11()
        {
            string produto = "caneta";
            decimal preco = 6.32m;
            //Formato monetário com duas casas pós vírgula
            //Respeita as configurações regionais do Windows
            Console.WriteLine(string.Format("Produto: {0}\nPreço: {1}",produto, preco.ToString("C2")));
            Console.ReadKey();
        }

        static void Ex12()
        {
            decimal valor = 1276.32m;
            Console.WriteLine(
            string.Format("{0:0.000}", valor) + "\n\n" + 
            string.Format("{0:#.###}", valor) + "\n\n" + 
            string.Format("{0:0,000.000}", valor) + "\n\n" + 
            string.Format("{0:#,###.###}", valor) + "\n\n" + 
            string.Format("{0:#,##0.00;(#,##0.00)}", valor) + "\n\n" +
            string.Format("{0:#,##0.00;(#,##0.00)}", -valor));

            Console.ReadKey();
        }

        static void Ex13()
        {
            decimal valor = 1276.32m;
            Console.WriteLine(
            valor.ToString("C2") + "\n\n" +
            valor.ToString("C2", new System.Globalization.CultureInfo("ja-jp")) + "\n\n"  +
            valor.ToString("C2", System.Globalization.CultureInfo.InvariantCulture));
            Console.ReadKey();
        }

        static void Ex14()
        {
            Console.WriteLine(DateTime.Now.ToString("d") + "\n" +
                             DateTime.Now.ToString("D") + "\n" +
                             DateTime.Now.ToString("t") + "\n" +
                             DateTime.Now.ToString("T") + "\n" +
                             DateTime.Now.ToString("f") + "\n" +
                             DateTime.Now.ToString("F") + "\n" +
                             DateTime.Now.ToString("g") + "\n" +
                             DateTime.Now.ToString("G") + "\n" +
                             DateTime.Now.ToString("M") + "\n" +
                             DateTime.Now.ToString("r") + "\n" +
                             DateTime.Now.ToString("s") + "\n" +
                             DateTime.Now.ToString("u") + "\n" +
                             DateTime.Now.ToString("Y") + "\n" +
                             DateTime.Now.ToString("dd") + "\n" +
                             DateTime.Now.ToString("ddd") + "\n" +
                             DateTime.Now.ToString("dddd") + "\n" +
                             DateTime.Now.ToString("MM") + "\n" +
                             DateTime.Now.ToString("MMM") + "\n" +
                             DateTime.Now.ToString("yy") + "\n" +
                             DateTime.Now.ToString("yyyy") + "\n" +
                             DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "\n" +
                             DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + "\n" +
                             DateTime.Now.ToString("São Paulo, dddd dd 'de' MMM 'de' yyyy") + "\n");

            Console.ReadLine();
        }

        static void Ex15()
        {
            string produto = "caneta";
            decimal preco = 6.32m;
            Console.WriteLine($"Produto: {produto}\nPreço: {preco}");
            Console.ReadKey();
        }
    }
}
