
using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse
{
    public class EquipmentWareHousePositionEntity : IEntity
    {
        //Data Properties
        public int Quantity { get; set; }

        //Navigation Properties
        public string EquipmentCatalogPositionId { get; set; } = default!;
        public virtual EquipmentCatalogPositionEntity EquipmentCatalogPosition { get; set; } = null!;
        public int WareHouseId { get; set; }
        public virtual WareHouseEntity WareHouse { get; set; } = null!;
    }
}
