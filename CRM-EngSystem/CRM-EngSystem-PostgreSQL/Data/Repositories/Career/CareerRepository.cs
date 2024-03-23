using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Builder.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Career
{
    public sealed class CareerRepository : ICareerRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public CareerRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is CareerEntity career)
            {
                await _context.Careers.AddAsync(career);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentCareerId && updatedEntity is CareerEntity updatedCareer)
            {
                var currentCareer = await _context.Careers.FindAsync(currentCareerId);
                if (currentCareer != null)
                {
                    _context.Entry(currentCareer).CurrentValues.SetValues(updatedCareer);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is CareerEntity career)
            {
                _context.Careers.Remove(career);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int careerId ? await _context.Careers
                    .Include(career => career.Contact)
                    .Include(career => career.Enterprise)
                    .FirstOrDefaultAsync(career => career.CareerId == careerId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
            => await new EntityLoadDataBuilder<CareerEntity>(_context.Careers.AsQueryable(), options)
                    .DeepInclude(career => career.Contact, contact => contact.Details)
                    .Include(career => career.Enterprise)
                    .ExecuteAsync();
    }
}
