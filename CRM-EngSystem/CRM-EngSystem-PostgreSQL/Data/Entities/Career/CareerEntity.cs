using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Career
{
    public class CareerEntity : IEntity
    {
        public int CareerId { get; set; }

        //Data Properties
        public string Position { get; set; } = default!;
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }

        //Navigation Properties
        public int ContactId { get; set; }
        public virtual ContactEntity Contact { get; set; } = default!;
        public int EnterpriseId { get; set; }
        public virtual EnterpriseEntity Enterprise { get; set; } = default!;
    }
}
