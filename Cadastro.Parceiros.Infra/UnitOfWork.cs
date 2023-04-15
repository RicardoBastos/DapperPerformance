using Cadastro.Parceiros.Domain.Interfaces;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;

namespace Cadastro.Parceiros.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SessionDB _session;

        public IProdutoRepository Produto { get; }
        public ICategoriaRepository Categoria { get; }


        public UnitOfWork(SessionDB session, ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
        {
            _session = session;
            Produto = produtoRepository;
            Categoria = categoriaRepository;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }
    }
}