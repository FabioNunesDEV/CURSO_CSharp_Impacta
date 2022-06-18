using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class DocumentoPF : IDocumento
    {
        private string _numero;
        public string Numero 
        {
            get => _numero;
            set => _numero = (value.Length == 11 ? value : throw new Exception("Documento inválido"));
        }

        public string MostarDocumento()
        {
            return "Número do CPF: " + this.Numero;
        }
    }
}
