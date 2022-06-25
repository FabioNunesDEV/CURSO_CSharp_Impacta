using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;

namespace Course
{
    class Program
    {
        static string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Users\fabio\Documents\CURSO EXERCICIOS\CURSO_CSharp_Impacta\Conceitos.CSharp.Cap13\Course\DBProdutos.mdf;Integrated Security = True; Connect Timeout = 30";


        static void Main(string[] args)
        {
            Ex01();
            Console.ReadKey();
        }
        static void Ex01()
        {
            SqlMapperExtensions.TableNameMapper = entidade =>
            {
                if (entidade == typeof(Produto))
                {
                    return "TBProdutos";
                }
                throw new Exception($"Entidade não suportada: {entidade}");
            };

            TestarDapperContribDeleteAll();
        }

        static void IncluirCategoria()
        {
            Console.Write("Informe a categoria: ");
            string categoria = Console.ReadLine();

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("Insert INTO TBCategorias(Descricao) Values (@Descricao)", new { Descricao = categoria });

                Console.WriteLine("Registros inseridos: " + registros);
            }
        }

        static void ListarCategorias()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var categorias = conn.Query<Categoria>("SELECT * FROM TBCategorias");
                foreach (var item in categorias)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Descrição: " + item.Descricao);
                    Console.WriteLine(new string('-', 40));

                }
            }
        }

        static void AlterarCategoria()
        {
            Console.Write("Informe o código da categoria: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Informe a nova categoria: ");
            string categoria = Console.ReadLine();

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("UPDATE TBCategorias SET Descricao = @Descricao WHERE Id=@Id", new { Id = codigo, Descricao = categoria });
                Console.WriteLine("Registros alterados: " + registros);
            }
        }

        static void RemoverCategoria()
        {
            Console.Write("Informe o código da categoria: ");
            int codigo = int.Parse(Console.ReadLine());

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("DELETE FROM TBCategorias WHERE Id=@Id", new { id = codigo });

                Console.WriteLine("Registro removidos: " + registros);
            }
        }

        static void ListarProdutosVM()
        {
            string sql = @"SELECT C.Descricao as Categoria, P.Descricao as Produto FROM TBCategorias C, TBProdutos P WHERE C.Id=P.IdCategoria";

            using (var conn = new SqlConnection(conexao))
            {
                var produtos = conn.Query<CategoriaProdutoVM>(sql);

                foreach (var item in produtos)
                {
                    Console.WriteLine("Categoria: " + item.Categoria);
                    Console.WriteLine("Produto: " + item.Produto);
                    Console.WriteLine(new string('-', 40));
                }
            }
        }

        static void TestarDapperContribGet()
        {
            using (var conn = new SqlConnection(conexao))
            {
                // retorna o produto com Id = 4
                var produto = conn.Get<Produto>(4);
                Console.WriteLine($"Descrição: {produto.Descricao}\nPreço: {produto.Preco}");
            }
        }

        static void TestaDapperContribGetAll()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var produto = conn.GetAll<Produto>();
                foreach (var item in produto)
                {
                    Console.WriteLine($"Descrição: {item.Descricao} - Preço: {item.Preco}");
                }
            }
        }

        static void TestarDapperContribInsert()
        {
            // inclui um novo produto. Observe que o Id não
            // foi informado, por ser uma chave primária.
            var novoProduto = new Produto
            {
                IdCategoria = 2,
                Descricao = "M305",
                Preco = 20
            };

            using (var conn = new SqlConnection(conexao))
            {
                var inserido = conn.Insert<Produto>(novoProduto);
                Console.WriteLine("Id registro criado: " + inserido);
            }
        }

        static void TestarDapperContribUpdate()
        {
            // altera os dados de um produto, com base no Id devidamente informado.
            var produtoAlterado = new Produto
            {
                Id = 12,
                IdCategoria = 2,
                Descricao = "M305b",
                Preco = 30
            };

            using (var conn = new SqlConnection(conexao))
            {
                var alterado = conn.Update<Produto>(produtoAlterado);
                Console.WriteLine("Registro alterado ?: " + alterado);
            }
        }

        static void TestarDapperContribDelete()
        {
            using (var conn = new SqlConnection(conexao))
            {                
                //remove o produto com base no Id (chave primária)
                var removido = conn.Delete<Produto>(new Produto { Id = 12 });

                Console.WriteLine("Registro deletado ?: " + removido);
            }                
        }

        static void TestarDapperContribDeleteAll()
        {
            using (var conn = new SqlConnection(conexao))
            {
                //remove todos os registros CUIDADO
                var removidoTodos = conn.DeleteAll<Produto>();

                Console.WriteLine("Registro deletado ?: " + removidoTodos);
            }
        }
    }
}
