using System;
using System.Globalization;

namespace Course
{
    public class Pessoa
    {
        ~Pessoa()
        {
            Console.WriteLine("Objeto sendo finalizado");
            Console.ReadKey();
        }

        public Pessoa()
        {
        }

        public Pessoa(double peso, double altura)
        {
            this.Peso = peso;
            this.Altura = altura;
        }

        public Pessoa(string nome, double peso, double altura):this(peso,altura)
        {
            this.Nome = nome;
        }
        public Pessoa(int idade, double peso, double altura) : this(peso, altura)
        {
            this.Idade = idade;
        }

        public Pessoa(string nome, int idade, double peso, double altura):this(idade,peso,altura)
        {
            this.Nome = nome;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public string GetPessoa()
        {
            return $"Nome: {this.Nome}\nIdade: {this.Idade}\nPeso: {this.Peso.ToString("F2",CultureInfo.InvariantCulture)}\nAltura: {this.Altura.ToString("F2",CultureInfo.InvariantCulture)}";
        }
    }
}
