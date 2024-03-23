namespace CRM_EngSystem.DTO.Contact
{
    public sealed class ContactEntityDTO
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string FirstPhoneNumber { get; set; } = default!;
        public string ExtraPhoneNumber { get; set; } = default!;
        public string FirstEmail { get; set; } = default!;
        public string ExtraEmail { get; set; } = default!;
        public string TelegramLink { get; set; } = default!;
        public string LinkedInLink { get; set; } = default!;
        public string ViberLink { get; set; } = default!;
        public string FaceBookLink { get; set; } = default!;
        public string WhatsappLink { get; set; } = default!;
        public string SkypeLink { get; set; } = default!;
        public string TwitterLink { get; set; } = default!;
        public string InstagramLink { get; set; } = default!;
        public int EnterpriseId { get; set; }
    }
}
