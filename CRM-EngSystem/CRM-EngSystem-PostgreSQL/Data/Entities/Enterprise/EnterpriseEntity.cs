using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise
{
    public class EnterpriseEntity : IEntity
    {
        public int EnterpriseId { get; set; }

        //Data Properties
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }

        //Navigation Properties
        public virtual EnterpriseDetailsEntity Details { get; set; } = null!;
        public virtual ICollection<ContactEntity>? Contacts { get; set; }
        public virtual ICollection<CommentEntity>? Comments { get; set; }
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public virtual ICollection<CareerEntity>? Careers { get; set; }
    }
}
