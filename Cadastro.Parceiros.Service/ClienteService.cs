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
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _repositoryCliente;

        ILogger _logger;

        public ClienteService(IUnitOfWork unitOfWork, IClienteRepository repositoryCliente, ILogger<ClienteService> logger)
        {
            _logger = logger;
            _repositoryCliente = repositoryCliente;
            _unitOfWork = unitOfWork;
        }
        public Task<ObterClientePorCpfResponse> ObterClientePorCpf(string cpf)
        {
            try
            {
                return _repositoryCliente.ObterClientePorCpf(cpf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task CadastrarCliente(CadastrarClienteRequest request)
        {
            try
            {
                var timer = new Stopwatch();

                timer.Start();
                _unitOfWork.BeginTransaction();

                _repositoryCliente.CadastrarCliente(request);

                _unitOfWork.Commit();
                timer.Stop();

                _logger.LogInformation($"Cadastrar cliente em : {timer.Elapsed}");

                return Task.CompletedTask;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}