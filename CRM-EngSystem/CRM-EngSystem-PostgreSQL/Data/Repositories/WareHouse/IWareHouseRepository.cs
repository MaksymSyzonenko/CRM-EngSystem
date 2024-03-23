using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.WareHouse
{
    public interface IWareHouseRepository : IRepository
    {
        Task AddEquipmentWareHousePositionAsync(EquipmentWareHousePositionEntity entity);
        Task UpdateEquipmentWareHousePositionAsync(string currentEntityId, EquipmentWareHousePositionEntity updatedEntity);
        Task<EquipmentWareHousePositionEntity> GetEquipmentWareHousePositionAsync(string equipmentWareHousePositionId);
        Task<IEnumerable<EquipmentWareHousePositionEntity>> GetAllEquipmentWareHousePositionsAsync();
        Task<IEnumerable<EquipmentWareHousePositionEntity>> GetEquipmentWareHousePositionsByQueryAsync(Func<EquipmentWareHousePositionEntity, bool> query);
    }
}
