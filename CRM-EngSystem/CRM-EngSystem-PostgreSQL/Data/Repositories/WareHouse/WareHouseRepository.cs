using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Builder.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.WareHouse
{
    public sealed class WareHouseRepository : IWareHouseRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public WareHouseRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is WareHouseEntity wareHouse)
            {
                await _context.WareHouses.AddAsync(wareHouse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentWareHouseId && updatedEntity is WareHouseEntity updatedWareHouse)
            {
                var currentWareHouse = await _context.WareHouses.FindAsync(currentWareHouseId);
                if (currentWareHouse != null)
                {
                    _context.Entry(currentWareHouse).CurrentValues.SetValues(updatedWareHouse);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is WareHouseEntity wareHouse)
            {
                _context.WareHouses.Remove(wareHouse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int wareHouseId ? await _context.WareHouses
                    .Include(wareHouse => wareHouse.EquipmentWareHousePositions)
                    .FirstOrDefaultAsync(wareHouse => wareHouse.WareHouseId == wareHouseId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync()
            => await _context.WareHouses
                .Include(wareHouse => wareHouse.EquipmentWareHousePositions)
                .ToListAsync();

        //EquipmentWareHousePosition Methods
        public async Task AddEquipmentWareHousePositionAsync(EquipmentWareHousePositionEntity entity)
        {
            if(entity != null)
            {
                await _context.EquipmentWareHousePositions.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEquipmentWareHousePositionAsync(string currentEntityId, EquipmentWareHousePositionEntity updatedEntity)
        {
            if (updatedEntity != null && (await _context.EquipmentWareHousePositions.FindAsync(currentEntityId)) is { } currentEquipmentWareHousePosition)
            {
                _context.Entry(currentEquipmentWareHousePosition).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EquipmentWareHousePositionEntity> GetEquipmentWareHousePositionAsync(string equipmentWareHousePositionId)
            => (await _context.EquipmentWareHousePositions.FindAsync(equipmentWareHousePositionId))!;

        public async Task<IEnumerable<EquipmentWareHousePositionEntity>> GetAllEquipmentWareHousePositionsAsync()
            => await _context.EquipmentWareHousePositions.ToListAsync();

        public async Task<IEnumerable<EquipmentWareHousePositionEntity>> GetEquipmentWareHousePositionsByQueryAsync(Func<EquipmentWareHousePositionEntity, bool> query)
        {
            var equipmentWareHousePositions = await GetAllEquipmentWareHousePositionsAsync();
            return query != null ? equipmentWareHousePositions.Where(query) : equipmentWareHousePositions;
        }

        

        public Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
