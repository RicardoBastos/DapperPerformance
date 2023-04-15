using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.Domain.Requests
{
    public class CadastrarProdutoRequest
    {
        public string Nome { get; set; }

        public int idCategoria { get; set; }
    }
}
