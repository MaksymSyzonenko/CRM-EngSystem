using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.DefaultData.Enterprise;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class EnterpriseDetailsEntityConfiguration : IEntityTypeConfiguration<EnterpriseDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<EnterpriseDetailsEntity> builder)
        {
            builder.HasKey(details => details.EnterpriseId);

            builder.HasData(EnterpriseDetailsDefaultData.EnterprisesDetails);
        }
    }
}
