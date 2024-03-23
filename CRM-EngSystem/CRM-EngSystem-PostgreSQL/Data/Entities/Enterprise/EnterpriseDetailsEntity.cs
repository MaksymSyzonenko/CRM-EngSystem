using CRM_EngSystem_PostgreSQL.Data.Entities.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise
{
    public class EnterpriseDetailsEntity : IEntity
    {
        //Data Properties
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
        //Navigation Properties
        public int EnterpriseId { get; set; }
        public virtual EnterpriseEntity Enterprise { get; set; } = null!;
    }
}
