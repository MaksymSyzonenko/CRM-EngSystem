using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse
{
    public class WareHouseEntity : IEntity
    {
        public int WareHouseId { get; set; }

        //Data Properties
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Region { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Street { get; set; } = default!;

        //Navigation Properties
        public virtual ICollection<EquipmentWareHousePositionEntity>? EquipmentWareHousePositions { get; set; }
    }
}
