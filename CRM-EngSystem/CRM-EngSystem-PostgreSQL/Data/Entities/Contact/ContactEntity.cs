using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Contact
{
    public class ContactEntity : IEntity
    {
        public int ContactId { get; set; }

        //Data Properties
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }

        //Navigation Properties
        public virtual ContactDetailsEntity Details { get; set; } = null!;
        public virtual UserEntity? User { get; set; }
        public int EnterpriseId { get; set; }
        public virtual EnterpriseEntity Enterprise { get; set; } = null!;
        public virtual ICollection<CommentEntity>? Comments { get; set; }
        public virtual ICollection<ContactOrderEntity>? ContactOrders { get; set; }
        public virtual ICollection<CareerEntity> Careers { get; set; } = default!;
    }
}
