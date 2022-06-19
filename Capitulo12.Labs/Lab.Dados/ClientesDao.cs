using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Models;

namespace Lab.Dados
{
    public class ClientesDao : Dao<Cliente, string>
    {
        public override Cliente Buscar(string chave)
        {
            throw new NotImplementedException();
        }

        public override int Incluir(Cliente item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Cliente> Listar(string chave = null)
        {
            throw new NotImplementedException();
        }

        public override int Remover(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
