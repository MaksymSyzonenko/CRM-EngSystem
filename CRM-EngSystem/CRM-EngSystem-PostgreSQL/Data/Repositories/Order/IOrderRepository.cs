using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Order
{
    public interface IOrderRepository : IRepository
    {
        Task AddEquipmentOrderPositionAsync(EquipmentOrderPositionEntity entity);
        Task UpdateEquipmentOrderPositionAsync(string currentEntityId, EquipmentOrderPositionEntity updatedEntity);
        Task RemoveEquipmentOrderPositionAsync(EquipmentOrderPositionEntity entity);
    }
}
