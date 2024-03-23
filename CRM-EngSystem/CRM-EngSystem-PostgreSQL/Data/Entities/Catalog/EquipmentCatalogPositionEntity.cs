using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Enums;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Catalog
{
    public class EquipmentCatalogPositionEntity : IEntity
    {
        public string EquipmentCatalogPositionId { get; set; } = default!;

        //Data Properties
        public string NameUA { get; set; } = default!;
        public string NameEN { get; set; } = default!;
        public EquipmentTypeValue Type { get; set; }
        public string Producer { get; set; } = default!;
        public string Country { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public string Link { get; set; } = default!;

        //Navigation Properties
        public virtual EquipmentOrderPositionEntity? EquipmentOrderPosition { get; set; }
        public virtual EquipmentWareHousePositionEntity? EquipmentWareHousePosition { get; set; }
    }
}
