using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace Cadastro.Parceiros.Infra
{
    public sealed class SessionDB : IDisposable
    {
        public DbConnection Connection { get; }
        public DbTransaction Transaction { get; set; }

        public SessionDB(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("SqlServer"));
            Connection.Open();
            //Transaction = Connection.BeginTransaction();
        }

        public void Dispose() => Connection?.Dispose();

    }
}
