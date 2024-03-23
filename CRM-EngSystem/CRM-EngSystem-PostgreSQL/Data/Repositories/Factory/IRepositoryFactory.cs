using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Factory
{
    public interface IRepositoryFactory
    {
        IRepository Instantiate<IEntity>(CRMEngSystemDbContext context);
    }
}
