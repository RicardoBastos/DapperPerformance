using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;

namespace Cadastro.Parceiros.Infra
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        ILogger<RepositoryBase<TEntity>> _logger;
        private SessionDB _session;

        public RepositoryBase(SessionDB session, ILogger<RepositoryBase<TEntity>> logger)
        {
            _session = session;
            _logger = logger;
        }


        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                await _session.Connection.InsertAsync<TEntity>(entity, _session.Transaction);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _session.Connection.GetAsync<TEntity>(id);
                return await _session.Connection.DeleteAsync<TEntity>(entity);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            try
            {
                var results = await _session.Connection.GetAllAsync<TEntity>();
                return results.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            try
            {
                return await _session.Connection.GetAsync<TEntity>(id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                return await _session.Connection.UpdateAsync<TEntity>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}