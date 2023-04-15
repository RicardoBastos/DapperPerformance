using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Responses;
using Dapper;
using Cadastro.Parceiros.Domain.Requests;
using Microsoft.Extensions.Logging;
using Cadastro.Parceiros.Domain.Entidades;
using System.Data;

namespace Cadastro.Parceiros.Infra
{


    public class CategoriaRepository : ICategoriaRepository
    {
        ILogger _logger;
        private SessionDB _session;



        public CategoriaRepository(ILogger<CategoriaRepository> logger, SessionDB session)
        {
            _logger = logger;
            _session = session;
        }


        public async Task CadastrarCategoria(CadastrarCategoriaRequest1 categoria)
        {
            try
            {
                _logger.LogInformation("teste");

                string sql = "INSERT INTO CATEGORIA(NOME)VALUES(@p_nome)";

                var param = new { p_nome = categoria.Nome };
                await _session.Connection.ExecuteAsync(sql, param, _session.Transaction);
                //return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

    }
}