using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;

namespace Cadastro.Parceiros.Infra.Database.Migrations
{
    public class DatabaseContext
    {
        private readonly DapperContext _context;
        ILogger _logger;

        public DatabaseContext(ILogger<DatabaseContext> logger, DapperContext context)
        {
            _context = context;
            _logger = logger;
        }
        public void CreateDatabase(string dbName)
        {
            try
            {
                var query = "SELECT * FROM sys.databases WHERE name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", dbName);
                using (var connection = _context.MasterConnection())
                {
                    var records = connection.Query(query, parameters);
                    if (!records.Any())
                        connection.Execute($"CREATE DATABASE {dbName}");
                }

                _logger.LogInformation("Executado o migration com sucesso");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Erro ao executar migration {0}", ex);
                throw;
            }

        }
    }
}