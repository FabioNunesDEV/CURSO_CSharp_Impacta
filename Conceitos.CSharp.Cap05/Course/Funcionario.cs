using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Funcionario
    {
        private string _nome;
        public string Nome { get => _nome; set => _nome = value; }

        private string _cargo;
        public string Cargo { get => _cargo; set => _cargo = value; }
    }
}
