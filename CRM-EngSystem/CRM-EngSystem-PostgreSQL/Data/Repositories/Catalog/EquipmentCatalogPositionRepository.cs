using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Builder.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Catalog
{
    public sealed class EquipmentCatalogPositionRepository : IEquipmentCatalogPositionRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public EquipmentCatalogPositionRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }
        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is EquipmentCatalogPositionEntity equipmentCatalogPosition)
            {
                await _context.EquipmentCatalogPositions.AddAsync(equipmentCatalogPosition);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is string currentEquipmentCatalogPositionId && updatedEntity is EquipmentCatalogPositionEntity updatedEquipmentCatalogPosition)
            {
                var currentEquipmentCatalogPosition = await _context.EquipmentCatalogPositions.FindAsync(currentEquipmentCatalogPositionId);
                if (currentEquipmentCatalogPosition != null)
                {
                    _context.Entry(currentEquipmentCatalogPosition).CurrentValues.SetValues(updatedEquipmentCatalogPosition);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is EquipmentCatalogPositionEntity equipmentCatalogPosition)
            {
                _context.EquipmentCatalogPositions.Remove(equipmentCatalogPosition);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is string equipmentCatalogPositionId ? await _context.EquipmentCatalogPositions
                    .Include(equipmentCatalogPosition => equipmentCatalogPosition.EquipmentOrderPosition)
                    .Include(equipmentCatalogPosition => equipmentCatalogPosition.EquipmentWareHousePosition)
                    .FirstOrDefaultAsync(equipmentCatalogPosition => equipmentCatalogPosition.EquipmentCatalogPositionId == equipmentCatalogPositionId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync()
            => await _context.EquipmentCatalogPositions
                .Include(equipmentCatalogPosition => equipmentCatalogPosition.EquipmentOrderPosition)
                .Include(equipmentCatalogPosition => equipmentCatalogPosition.EquipmentWareHousePosition)
                .ToListAsync();

        public Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
