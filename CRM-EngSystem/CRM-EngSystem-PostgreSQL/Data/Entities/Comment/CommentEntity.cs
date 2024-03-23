using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Comment
{
    public class CommentEntity : IEntity
    {
        public int CommentId { get; set; }

        //Data Properties
        public string Text { get; set; } = default!;
        public DateTime DateTimeCreate { get; set; }

        //Navigation Properties
        public int AuthorId { get; set; }
        public virtual UserEntity Author { get; set; } = default!;
        public int? RecipientContactId { get; set; }
        public virtual ContactEntity? RecipientContact { get; set; }
        public int? RecipientEnterpriseId { get; set; }
        public virtual EnterpriseEntity? RecipientEnterprise { get; set; }
        public int? RecipientOrderId { get; set; }
        public virtual OrderEntity? RecipientOrder { get; set; }
    }
}
