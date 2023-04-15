using Cadastro.Parceiros.Domain.Entidades;
using Cadastro.Parceiros.Domain.Interfaces;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cadastro.Parceiros.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _uow;

        public ProdutoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task CadastrarProdutoAsync(CadastrarProdutoRequest request)
        {
            try
            {
                _uow.BeginTransaction();
                await _uow.Produto.CreateAsync(new Produto(request.Nome, request.idCategoria));
                _uow.Commit();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<Produto> ObterProdutoPorIdAsync(int id)
        {
            try
            {
                return await _uow.Produto.FindByIdAsync(id);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}