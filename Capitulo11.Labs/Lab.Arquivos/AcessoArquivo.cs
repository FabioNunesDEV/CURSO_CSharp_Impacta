using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab.Models;

namespace Lab.Arquivos
{
    public class AcessoArquivo<T>
    {
        static string path = @"D:\Documentos\Projetos\Impacta\CSharp\Capitulo12.Labs";
        public static void GerarExtrato<T>(T conta) where T : Conta
        {
            try
            {
                if (!Directory.Exists(path + @"\Extrato"))
                {
                    Directory.CreateDirectory(path + @"\Extrato");
                }
                string arquivo = "extrato_" + $"{DateTime.Now: yyyyMMddHHmmsss}.txt";
                File.WriteAllText(path + @"\Extrato\" + arquivo, conta.MostrarExtrato());
            }
            catch
            {
                throw;
            }

        }
    }
}

