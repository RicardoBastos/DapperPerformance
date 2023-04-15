using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Cadastro.Parceiros.Infra.Database
{
    public class OracleStrategy : IDbStrategy
    {
        public IDbConnection GetConnection(IConfiguration configuration)
        {
            var connection = new OracleConnection(configuration.GetConnectionString("Oracle"));
            connection.Open();
            return connection;
        }
    }
}