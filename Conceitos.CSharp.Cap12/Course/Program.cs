using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:\Users\fabio\Documents\CURSO EXERCICIOS\CURSO_CSharp_Impacta\conteudo.txt";
            string diretorio = @"D:\Users\fabio\Documents\CURSO EXERCICIOS\CURSO_CSharp_Impacta";
            Ex18(file);

            Console.ReadKey();
        }

        public static void Ex01(string path)
        {            
            string texto = File.ReadAllText(path);

            Console.WriteLine(texto);
        }

        public static void Ex02(string path)
        {
            string[] linhas = File.ReadAllLines(path);

            foreach (var item in linhas)
            {
                Console.WriteLine("-> " + item);
            }
        }

        public static void Ex03(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);

            string textoOriginal = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write(bytes[i] + " ");

                if (i > 0 && i % 20 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void Ex04(string path)
        {
            string conteudo = "Conteúdo: Gravação usando WriteAllText";
            File.WriteAllText(path, conteudo);

            Console.WriteLine("Arquivo criado");
        }

        public static void Ex05(string path)
        {
            string[] linhas = { "Curso 1:Java", "Curso 2:Node.js", "Curso 3:Asp.Net" };
            File.WriteAllLines(path, linhas);

            Console.WriteLine("Arquivo criado");
        }

        public static void Ex06(string path)
        {
            byte[] bytes = { 73, 109, 112, 97, 99, 116, 97, 32, 84,101, 99, 110, 111, 108, 111, 103, 105, 97 };
            File.WriteAllBytes(path, bytes);

            Console.WriteLine("Arquivo criado");
        }

        public static void Ex07(string path)
        {
            string texto = "\n\nLista de Tópicos";
            File.AppendAllText(path, texto);

            Console.WriteLine("Arquivo criado");
        }

        public static void Ex08(string path)
        {            
            string[] linhas = { "\nLeitura", "Gravação" };
            File.AppendAllLines(path, linhas);
            Console.WriteLine("Linhas adicionadas");
        }

        public static void Ex09(string path)
        {
            Directory.CreateDirectory(path);
            Console.WriteLine("Diretório criado");
        }

        public static void Ex10(string path)
        {
            Directory.Delete(path);
            Console.WriteLine("Diretório removido");
        }

        public static void Ex11(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("O diretório existe");
            }
            else
            {
                Console.WriteLine("O diretório não existe, ou foi removido");
            }
        }

        public static void Ex12(string path)
        {
            string[] pastas = Directory.GetDirectories(path);
            foreach (var item in pastas)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ex13(string path)
        {
            string[] pastas = Directory.GetFiles(path);
            foreach (var item in pastas)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ex14(string path)
        {
            //Objeto usado para estabelecer o acesso ao stream
            FileStream file = new FileStream(path, FileMode.Open);
            //Objeto usado para ler os caracteres do FileStream
            StreamReader reader = new StreamReader(file);
            //obtém acesso ao próximo caractere no stream
            while (reader.Peek() != -1)
            {
                Console.Write((char)reader.Read()); //escreve o caractere lido
            }
            reader.Close();
            file.Close();
        }

        public static void Ex15(string path)
        {
            StreamReader reader = new StreamReader(path);
            //Forma 1 - leitura linha por linha
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                Console.WriteLine(linha);
            }

            Console.WriteLine(new string('-', 30));
            //Forma 2 - leitura de todo o arquivo
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }

        public static void Ex16(string path)
        {
            //Obtém o objeto para acessar o fluxo
            StreamWriter writer = new StreamWriter(path,true);
            //define o conteúdo a ser armazenado no arquivo
            writer.WriteLine("Conteúdo do arquivo");
            writer.WriteLine("Mais conteúdo para o arquivo");
            //fecha o stream para liberar o conteúdo para o arquivo
            writer.Close();
            Console.WriteLine("Arquivo criado com sucesso");
        }

        public static void Ex17(string path)
        {
            //Objeto usado para estabelecer o acesso ao stream
            FileStream file = new FileStream(path, FileMode.Open);
            //Objeto usado para manipular os streams obtidos por FileStream
            BinaryReader reader = new BinaryReader(file);
            //cria um array com a quantidade do início ao fim de bytes no stream
            byte[] bytes = new byte[reader.BaseStream.Length];
            //efetua a leitura dos bytes do arquivo, e os armazena no
            //array criado
            int valor;
            int posicao = 0;
            while ((valor = reader.Read()) != -1)
            {
                bytes[posicao++] = (byte)valor;
            }
            Console.WriteLine("Bytes lidos com sucesso");
        }

        public static void Ex18(string path)
        {
            //Objeto usado para estabelecer o acesso ao stream
            FileStream file = new FileStream(
            path,
            FileMode.Create, //sempre cria um novo arquivo
            FileAccess.Write); //executa apenas gravação
                               //Objeto usado para manipular os streams obtidos por FileStream
            BinaryWriter writer = new BinaryWriter(file);
            //cria um array com os bytes a serem gravados
            byte[] dados = { 73, 109, 112, 97, 99, 116, 97, 32, 84, 101, 99, 110, 111, 108, 111, 103, 105, 97 };
            //escreve cada byte no stream
            foreach (var item in dados)
            {
                writer.Write(item);
            }
            //fecha cada um dos streams para liberar o conteúdo para o arquivo
            writer.Close();
            file.Close();
            Console.WriteLine("Bytes gravados com sucesso");
        }
    }
}
