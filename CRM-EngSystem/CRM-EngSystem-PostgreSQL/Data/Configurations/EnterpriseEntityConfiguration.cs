using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.DefaultData.Enterprise;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class EnterpriseEntityConfiguration : IEntityTypeConfiguration<EnterpriseEntity>
    {
        public void Configure(EntityTypeBuilder<EnterpriseEntity> builder)
        {
            builder.HasKey(enterprise => enterprise.EnterpriseId);

            builder.HasMany(enterprise => enterprise.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.CustomerId);

            builder.HasOne(enterprise => enterprise.Details)
                .WithOne(details => details.Enterprise)
                .HasForeignKey<EnterpriseDetailsEntity>(details => details.EnterpriseId)
                .IsRequired();

            builder.HasData(EnterpriseDefaultData.Enterprises);
        }
    }
}
