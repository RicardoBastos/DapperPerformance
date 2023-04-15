using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Parceiros.Infra.Database
{
    public class SqlServerStrategy : IDbStrategy
    {
        public IDbConnection GetConnection(IConfiguration configuration)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("SqlServer"));

            connection.Open();
            return connection;
        }
    }
}