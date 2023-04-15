using Cadastro.Parceiros.Domain.Entidades;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Cadastro.Parceiros.Infra
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SessionDB configuration, ILogger<RepositoryBase<Produto>> logger) : base(configuration, logger)
        { }
    }
}
