using CRM_EngSystem_PostgreSQL.Data.Analytic.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Analytic.Contact
{
    public sealed class ContactAnalytic : IContactAnalytic
    {
        public async Task<IAnalyticEntityResult> GetAnalyticForEntity(IEntity entity)
        {
            await Task.Delay(100);
            return new ContactAnalyticResult();
        }

        public async Task<IAnalyticEntitiesResult> GetAnalyticForEntities(IEnumerable<IEntity> entity)
        {
            await Task.Delay(100);
            return new ContactsAnalyticResult();
        }
    }
}
