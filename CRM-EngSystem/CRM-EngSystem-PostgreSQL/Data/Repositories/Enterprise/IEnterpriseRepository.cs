using CRM_EngSystem_PostgreSQL.Data.Builder.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise
{
    public interface IEnterpriseRepository : IRepository
    {
        Task AddEnterpriseDetailsAsync(EnterpriseDetailsEntity entity);
        Task UpdateEnterpriseDetailsAsync(int currentEntityId, EnterpriseDetailsEntity updatedEntity);
        //Task<IEnumerable<EnterpriseEntity>> GetAllEntitiesAsync(EnterpriseLoadDataOptions options);
    }
}
