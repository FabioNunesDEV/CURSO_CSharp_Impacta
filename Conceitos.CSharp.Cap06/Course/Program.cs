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
            Cliente pf = new Cliente()
            {
                Documento = new DocumentoPF()
                {
                    Numero = "12345678901"
                },
                NomeCliente = "Pessoa Física"
            };

            Cliente pj = new Cliente()
            {
                Documento = new DocumentoPJ()
                {
                    Numero = "12345678901234"
                },
                NomeCliente = "Pessoa Jurídica"
            };

            Console.WriteLine(pf.Documento.MostarDocumento());

            Console.WriteLine(pj.Documento.MostarDocumento());

            Console.ReadKey();
        }
    }
}
