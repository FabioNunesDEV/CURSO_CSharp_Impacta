using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Texto : ITextA, ITextB
    {
        public bool resultado => throw new NotImplementedException();

        public string MostrarDados()
        {
            throw new NotImplementedException();
        }
    }
}
