using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Enums;
using CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder;

namespace CRM_EngSystem_PostgreSQL.Data.Order
{
    public class OrderEntity : IEntity
    {
        public int OrderId { get; set; }

        //Data Properties
        public OrderStatusValue Status { get; set; }
        public DateTime DateTimeActiveStatusStart { get; set; }
        public DateTime? DateTimeOfferStatusStart { get; set; }
        public DateTime? DateTimeProcessingStatusStart { get; set; }
        public DateTime? DateTimeCompletedStatusStart { get; set; }
        public PriorityValue Priority { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        public int InitiatorId { get; set; }

        //Navigation Properties
        public int CustomerId { get; set; }
        public virtual EnterpriseEntity Customer { get; set; } = null!;
        public virtual ICollection<EquipmentOrderPositionEntity>? EquipmentOrderPositions { get; set; }
        public virtual ICollection<ContactOrderEntity> ContactOrders { get; set; } = null!;
        public virtual ICollection<CommentEntity>? Comments { get; set; }
    }
}
