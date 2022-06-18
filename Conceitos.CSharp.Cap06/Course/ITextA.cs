using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public interface ITextA
    {
        
        bool resultado { get; }
        string MostrarDados();
        /*
        bool resultado { get => true; }
        string MostrarDados()
        {
            return "Retorno método ITextA";
        }
        */
    }
}
