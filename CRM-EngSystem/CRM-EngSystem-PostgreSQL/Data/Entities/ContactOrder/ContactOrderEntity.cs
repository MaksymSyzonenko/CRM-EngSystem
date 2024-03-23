using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Order;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder
{
    public class ContactOrderEntity : IEntity
    {
        public int ContactId { get; set; }
        public int OrderId { get; set; }
        public virtual ContactEntity Contact { get; set; } = null!;
        public virtual OrderEntity Order { get; set; } = null!;
    }
}
