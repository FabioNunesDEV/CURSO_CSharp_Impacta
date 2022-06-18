using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class DocumentoPJ : IDocumento
    {
        private string _numero;
        public string Numero 
        {
            get => _numero;
            set => _numero = (value.Length == 14 ? value : throw new Exception("Documento inválido")); 
        }

        public string MostarDocumento()
        {
            return "Número do CNPJ: " + this.Numero;
        }
    }
}
