namespace CRM_EngSystem.DTO.Enterprise
{
    public sealed class EnterpriseEntityDTO
    {
        public int EnterpriseId { get; set; }
        public string? NameUA { get; set; }
        public string? NameEN { get; set; }
        public string? OwnershipFormUA { get; set; }
        public string? OwnershipFormEN { get; set; }
        public string? IndustryBranch { get; set; }
        public string? Franchise { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
    }
}
