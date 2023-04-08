using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.Domain.Requests
{
    public class CadastrarClienteRequest
    {
        public int IdCliente { get; set; }
        public string? Cpf { get; set; }
    }
}
