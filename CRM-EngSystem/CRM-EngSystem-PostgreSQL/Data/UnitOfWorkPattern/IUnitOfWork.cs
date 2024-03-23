using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task Commit();
        IRepository Repository<IEntity>();
    }
}
