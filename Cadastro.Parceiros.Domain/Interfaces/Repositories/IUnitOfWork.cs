using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void BeginTransaction();
        IProdutoRepository Produto { get; }
        ICategoriaRepository Categoria { get; }
    }
}
