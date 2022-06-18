using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.CSharp.Cap03
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex02();
        }

        static void Ex01()
        {
            // Declarar e instanciar um objeto do tipo Automovel.
            Automovel01 carro = new Automovel01();

            // Definir valor aos seus campos/atributos
            carro.Fabricante = "Toyota";
            carro.Modelo = "Corolla";
            carro.Placa = "Preto";
            carro.Cor = "Preto";
            carro.Ano = 2013;

            // Exibir os dados na listbox
            Console.WriteLine("Fabricante: " + carro.Fabricante);
            Console.WriteLine("Modelo: " + carro.Modelo);
            Console.WriteLine("Placa: " + carro.Placa);
            Console.WriteLine("Cor: " + carro.Cor);
            Console.WriteLine("Ano: " + carro.Ano);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex02()
        {
            System.Windows.Forms.MessageBox.Show("Exemplo de Namespace");
            Console.ReadKey();
        }

        static void Ex03()
        {
            // Declarar e instanciar um objeto do tipo Automovel.
            Automovel02 carro = new Automovel02();

            // Definir valor aos seus campos/atributos
            carro.Fabricante = "Toyota";
            carro.Modelo = "Corolla";

            // Exibir os dados na listbox;
            Console.WriteLine("Fabricante: " + carro.Fabricante);
            Console.WriteLine("Modelo: " + carro.Modelo);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex04()
        {
            // Declaração de classe de forma implicita
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Mirosmar";
            funcionario.Salario = 3000;

            // Declaração de classe de forma explicita
            funcionario = new Funcionario()
            {
                Nome = "Mirosmar",
                Salario = 3000
            };
        }

        static void Ex05()
        {
            // Objeto anonimo

            var objeto = new
            {
                Descricao = "Objeto Anônimo",
                DataCriacao = DateTime.Now
            };

        }

        static void Ex06()
        {
            for (byte i = 0; i <= 4; i++)
            {
                Console.WriteLine(Enum.GetName(typeof(EstadosCivis), i));
            }

            Console.ReadKey();
        }

        static void Ex07()
        {
            Endereco comercial = new Endereco()
            {
                Rua = "José Paulino"
            };

            comercial.Bairro = "Cerqueira Cesar";
            comercial.Cidade = "São Paulo";
            comercial.UF = "SP";
            comercial.CEP = "01311-919";
            Console.WriteLine(comercial.ExibirCompleto());

            Console.ReadKey();
        }

        static void Ex08()
        {
            int n1 = 10;
            int n2 = 15;

            // O retorno do método é atribuido à variavel.
            int resultado = Multiplicar(n1, n2);

            Console.WriteLine(resultado);
            Console.ReadKey();
        }

        static void Ex09()
        {
            Automovel03 carro = new Automovel03();
            carro.Fabricante = "Toyota";
            carro.Modelo = "Corolla";

            Console.WriteLine("Fabricante: " + carro.Fabricante);
            Console.WriteLine("Modelo: " + carro.Modelo);
            Console.WriteLine(new string('-', 30));

            System.Windows.Forms.MessageBox.Show(carro.ExibirDados());

            Console.ReadKey();
        }

        static void Ex10()
        {
            Pessoa gente = new Pessoa();
            gente.Nome = "Mirosmar";
            gente.Idade = 26;

            Console.WriteLine(gente.ExibirDados());
            Console.WriteLine();
            Console.WriteLine(gente.ExibirDados("Curso C#"));

            Console.ReadKey();
        }

        static void Ex11()
        {
            string texto = @"São cabeçalhos, rodapés, construções de gráficos coordenados com a aparência do documento.";

            string textoTratado = Metodos.RetirarAcentos(texto);

            Console.WriteLine(texto);
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(textoTratado);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex12()
        {
            string texto = @"São cabeçalhos, rodapés, construções de gráficos coordenados com a aparência do documento.";

            string textoTratado = texto.RetirarAcentosExtensao();

            Console.WriteLine(texto);
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(textoTratado);
            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }

        static void Ex13()
        {
            int m = 10;
            Console.WriteLine("Valor de m antes: " + m);
            MudarValor01(m);
            Console.WriteLine("Valor de m depois: " + m);

            Console.ReadKey();
        }

        static void Ex14()
        {
            int m = 10;
            Console.WriteLine("Valor de m antes: " + m);
            MudarValor02(ref m);
            Console.WriteLine("Valor de m depois: " + m);

            Console.ReadKey();
        }

        static void Ex15()
        {
            int m;
            AtribuirValor(out m);
            Console.WriteLine("Valor atribuido a m: " + m);
            Console.ReadKey();
        }

        static void Ex16()
        {
            Console.WriteLine(ApresentarEstado());
            Console.WriteLine(ApresentarEstado(Estados.BA));

            Console.ReadKey();
        }

        static void Ex17()
        {
            double valor = 100;
            double v1 = CalcularLiquido(valor);         // chamada1
            double v2 = CalcularLiquido(valor, 10);     // chamada2
            double v3 = CalcularLiquido(valor, 10, 18); // chamada3

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine(v3);

            Console.ReadKey();
        }

        static void Ex18()
        {
            double valor = 1000;
            double v1 = CalcularLiquido(valor, imposto: 5);
            Console.WriteLine(v1);

            Console.ReadKey();
        }

        // Definição do método.
        private static int Multiplicar(int valor1, int valor2)
        {
            // Retorna o resultado da multiplicação.
            // entre o valor1 e o valor2.
            return valor1 * valor2;
        }

        private static void MudarValor01(int x)
        {
            x += 100;
        }

        private static void MudarValor02(ref int x)
        {
            x += 100;
        }

        private static void AtribuirValor(out int m)
        {
            m = 100;
        }

        private static string ApresentarEstado(Estados estado = Estados.SP)
        {
            return $"O estado informado foi {estado}";
        }

        private static double CalcularLiquido(double valor, double taxa=0, double imposto = 0)
        {
            double desc1 = valor * taxa / 100;
            double desc2 = valor * imposto / 100;
            double valorLiquido = valor - desc1 - desc2;

            return valorLiquido;
        }
    }

    class Automovel01
    {
        // Inicializa com Toyota
        public string Fabricante = "Toyota";
        // Inicializa com Corolla
        public string Modelo = "Corola";
        // Inicializa com null
        public string Placa;
        // Inicializa com null
        public string Cor;
        // Inicializa com zero
        public short Ano;
    }

    class Automovel02
    {
        // Campo público Fabricante, será visível pelo objeto.
        public string Fabricante;
        // Campo particular
        private string _modelo;
        // Propriedade que encapsula o campo é pública
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
    }

    class Automovel03
    {
        private string _fabricante;
        public string Fabricante { get { return _fabricante; } set { _fabricante = value; } }

        private string _modelo;
        public string Modelo { get { return _modelo; } set { _modelo = value; } }

        public string ExibirDados()
        {
            return "Marca: " + Fabricante + "\nModelo: " + Modelo;
        }
    }

    class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public double Irpf { get => Salario * 0.1; }
        public Funcionario()
        {
        }

        public Funcionario(string nome, double salario)
        {
            this.Nome = nome;
            this.Salario = salario;
        }
    }

    enum EstadosCivis : byte
    {
        Casado,
        Solteiro,
        Viuvo,
        Separado,
        Outro
    }

    struct Endereco
    {

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public string ExibirCompleto()
        {
            return $"Rua{Rua}\nBairro{Bairro}\nCidade{Cidade} - {UF}\nCep: {CEP}";
        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        public byte Idade { get; set; }

        public string ExibirDados()
        {
            return string.Format("Nome: {0}\nIdade: {1} anos", Nome, Idade.ToString());
        }

        public string ExibirDados(string observacao) 
        {
            return string.Format("Nome: {0}\nIdade: {1} anos\nObs.: {2}", Nome, Idade.ToString(), observacao);
        }
    }

    static class Metodos
    {
        public static string RetirarAcentos (string texto)
        {
            string comAcentos = "ÄÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛÙüúûùÇç";
            string semAcentos = "AAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto;
        }

        public static string RetirarAcentosExtensao(this string texto)
        {
            string comAcentos = "ÄÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛÙüúûùÇç";
            string semAcentos = "AAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto;
        }
    }

    enum Estados : sbyte
    {
        SP,MG,RJ,ES,BA
    }

}
