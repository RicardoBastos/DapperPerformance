using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Parceiros.Infra.Database
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;
        public IDbConnection Connection { get; }

        public DbContext SetStrategy(EProviderType providerType)
        {

            switch (providerType)
            {
                case EProviderType.SqlServer:
                    _dbStrategy = new SqlServerStrategy();
                    break;
                case EProviderType.Oracle:
                    _dbStrategy = new OracleStrategy();
                    break;
                default:
                    _dbStrategy = new OracleStrategy();
                    break;
            }

            return this;
        }

        public IDbConnection GetDbContext(IConfiguration configuration)
        {
            return _dbStrategy.GetConnection(configuration);

        }
    }
}