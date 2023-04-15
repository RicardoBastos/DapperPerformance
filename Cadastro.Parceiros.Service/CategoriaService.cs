using Cadastro.Parceiros.Domain.Interfaces;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cadastro.Parceiros.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _uow;
        //private readonly ICategoriaRepository _categoriaRepositorio;

        ILogger _logger;

        public CategoriaService(IUnitOfWork uow, ILogger<CategoriaService> logger)
        {
            _logger = logger;
            _uow = uow;
            //_categoriaRepositorio = categoriaRepositorio;
        }

        public async Task CadastrarCategoria(CadastrarCategoriaRequest1 request)
        {
            try
            {
                var timer = new Stopwatch();
                timer.Start();
                _uow.BeginTransaction();
                await _uow.Categoria.CadastrarCategoria(request);

                await _uow.Categoria.CadastrarCategoria(request);

                _uow.Commit();

                timer.Stop();
                _logger.LogInformation($"Cadastrado em categoria em : {timer.Elapsed}");

                //return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"0001 - {0}", ex.ToString());
                _uow.Rollback();
                throw;
            }
        }

    }
}