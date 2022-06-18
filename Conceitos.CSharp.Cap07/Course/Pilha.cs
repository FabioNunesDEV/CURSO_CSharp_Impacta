using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Pilha
    {
        private ArrayList elementos = new ArrayList();

        public object Top
        {
            get => elementos[elementos.Count - 1];
        }
        public void Push (object item)
        {
            elementos.Add(item);
        }

        public object Pop()
        {
            object aux = null;
            if (elementos.Count == 0)
            {
                return aux;
            }

            aux = Top;
            elementos.RemoveAt(elementos.Count - 1);
            return aux;
        }
    }
}
