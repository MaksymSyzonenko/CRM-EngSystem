using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise
{
    public sealed class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public EnterpriseRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is EnterpriseEntity enterprise)
            {
                await _context.Enterprises.AddAsync(enterprise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentEnterpriseId && updatedEntity is EnterpriseEntity updatedEnterprise)
            {
                var currentEnterprise = await _context.Enterprises.FindAsync(currentEnterpriseId);
                if (currentEnterprise != null)
                {
                    _context.Entry(currentEnterprise).CurrentValues.SetValues(updatedEnterprise);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is EnterpriseEntity enterprise)
            {
                _context.Enterprises.Remove(enterprise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int enterpriseId ? await _context.Enterprises
                    .Include(enterprise => enterprise.Details)
                    .Include(enterprise => enterprise.Contacts)!
                        .ThenInclude(contact => contact.Details)
                    .Include(enterprise => enterprise.Orders)
                    .Include(enterprise => enterprise.Comments)
                    .FirstOrDefaultAsync(enterprise => enterprise.EnterpriseId == enterpriseId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
            => await new EntityLoadDataBuilder<EnterpriseEntity>(_context.Enterprises.AsQueryable(), options)
                    .Include(enterprise => enterprise.Details)
                    .Include(enterprise => enterprise.Orders!)
                    .DeepInclude(enterprise => enterprise.Contacts!, contact => contact.Details)
                    .Include(enterprise => enterprise.Comments!)
                    .ExecuteAsync();

        //EnterpriseDetails Methods
        public async Task AddEnterpriseDetailsAsync(EnterpriseDetailsEntity entity)
        {
            if(entity != null)
            {
                await _context.EnterprisesDetails.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEnterpriseDetailsAsync(int currentEntityId, EnterpriseDetailsEntity updatedEntity)
        {
            if (updatedEntity != null && (await _context.EnterprisesDetails.FindAsync(currentEntityId)) is { } currentEnterpriseDetails)
            {
                _context.Entry(currentEnterpriseDetails).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
