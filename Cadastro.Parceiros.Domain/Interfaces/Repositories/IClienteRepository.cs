using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<ObterClientePorCpfResponse> ObterClientePorCpf(string cpf);
        Task CadastrarCliente(CadastrarClienteRequest cliente);

    }
}
