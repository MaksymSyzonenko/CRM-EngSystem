using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Core
{
    public interface IRepository
    {
        Task AddEntityAsync(IEntity entity);
        Task RemoveEntityAsync(IEntity entity);
        Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity);
        Task<IEntity?> GetEntityAsync<TKey>(TKey entityId);
        Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options);
    }
}
