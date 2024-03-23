using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Order
{
    public class EquipmentOrderPositionEntity : IEntity
    {
        //Data Properties
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int MarkUp { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal SellPrice { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantityToTake { get; set; }
        public decimal ShippingCost { get; set; }

        //Navigation Properties
        public string EquipmentCatalogPositionId { get; set; } = default!;
        public virtual EquipmentCatalogPositionEntity EquipmentCatalogPosition { get; set; } = null!;
        public int OrderId { get; set; }
        public virtual OrderEntity Order { get; set; } = null!;
    }
}
