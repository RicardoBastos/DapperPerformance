using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Responses;
using Dapper;
using Cadastro.Parceiros.Domain.Requests;
using Microsoft.Extensions.Logging;


namespace Cadastro.Parceiros.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        private SessionDB _session;
        ILogger _logger;

        public ClienteRepository(ILogger<ClienteRepository> logger, SessionDB session)
        {
            _logger = logger;
            _session = session;
        }

        public Task CadastrarCliente(CadastrarClienteRequest cliente)
        {
            try
            {
                _logger.LogInformation("Iniciando");
                string sql = "INSERT INTO TBL_TESTE(CPF,ID_CLIENTE)VALUES(@p_cpf, @p_id_cliente)";

                var param = new { p_cpf = cliente.Cpf, p_id_cliente = cliente.IdCliente };
                _session.Connection.Execute(
                     sql
                    , param
                    , _session.Transaction);

                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<ObterClientePorCpfResponse> ObterClientePorCpf(string cpf)
        {
            try
            {
                var query = @"SELECT ID_CLIENTE IdCliente FROM TBL_TESTE WHERE CPF = @p_cpf_cnpj";

                var result = await _session.Connection.QueryFirstAsync<ObterClientePorCpfResponse>(query, new { p_cpf_cnpj = cpf });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}