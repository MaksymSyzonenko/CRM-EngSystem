using CRM_EngSystem_PostgreSQL.Data.Repositories.Factory;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;
using CRM_EngSystem_PostgreSQL.Data.Core;

namespace CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CRMEngSystemDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(CRMEngSystemDbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public async Task Commit()
        {
            await using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public IRepository Repository<IEntity>()
        {
            if (!_repositories.TryGetValue(typeof(IEntity), out object? repository))
            {
                repository = _repositoryFactory.Instantiate<IEntity>(_context);
                _repositories.TryAdd(typeof(IEntity), repository);
            }

            return (IRepository)repository;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
