using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Managements.Core;
using CRM_EngSystem_PostgreSQL.Data.Order;

namespace CRM_EngSystem_PostgreSQL.Data.Managements.Order
{
    public interface IOrderManager : IManager
    {
        Task<bool> AddEquipmentToOrderAsync(EquipmentCatalogPositionEntity equipmentCatalogPosition, OrderEntity order);
    }
}
