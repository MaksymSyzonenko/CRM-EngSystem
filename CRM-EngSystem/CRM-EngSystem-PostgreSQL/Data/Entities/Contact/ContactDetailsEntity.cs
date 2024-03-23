using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Contact
{
    public class ContactDetailsEntity : IEntity
    {
        //Data Properties
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string FirstPhoneNumber { get; set; } = default!;
        public string? ExtraPhoneNumber { get; set; }
        public string FirstEmail { get; set; } = default!;
        public string? ExtraEmail { get; set; }
        public string? TelegramLink { get; set; }
        public string? LinkedInLink { get; set; }
        public string? ViberLink { get; set; }
        public string? FaceBookLink { get; set; }
        public string? WhatsappLink { get; set; }
        public string? SkypeLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }

        //Navigation Properties
        public int ContactId { get; set; }
        public virtual ContactEntity Contact { get; set; } = null!;
    }
}
