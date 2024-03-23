using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.User
{
    public class UserEntity : IEntity
    {
        //Data Properties
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;

        //Navigation Properties
        public int ContactId { get; set; }
        public virtual ContactEntity Contact { get; set; } = null!;
        public virtual ICollection<CommentEntity>? Comments { get; set; }
    }
}
