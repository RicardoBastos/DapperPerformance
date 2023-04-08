using Cadastro.Parceiros.Domain.Interfaces;

namespace Cadastro.Parceiros.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SessionDB _session;

        public UnitOfWork(SessionDB session)
        {
            _session = session;
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

        public void Dispose() => _session.Transaction?.Dispose();
    }
}