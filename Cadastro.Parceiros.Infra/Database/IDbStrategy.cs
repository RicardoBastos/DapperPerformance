using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Parceiros.Infra.Database
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection(IConfiguration configuration);
    }
}