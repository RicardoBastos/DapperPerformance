using Cadastro.Parceiros.Domain.Entidades;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<Produto> ObterProdutoPorIdAsync(int id);

        Task CadastrarProdutoAsync(CadastrarProdutoRequest request);

    }
}
