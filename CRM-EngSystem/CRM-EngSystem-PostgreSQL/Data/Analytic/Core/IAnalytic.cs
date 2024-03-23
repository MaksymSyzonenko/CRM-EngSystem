using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Analytic.Core
{
    public interface IAnalytic
    {
        Task<IAnalyticEntityResult> GetAnalyticForEntity(IEntity entity);
        Task<IAnalyticEntitiesResult> GetAnalyticForEntities(IEnumerable<IEntity> entity);
    }
}
