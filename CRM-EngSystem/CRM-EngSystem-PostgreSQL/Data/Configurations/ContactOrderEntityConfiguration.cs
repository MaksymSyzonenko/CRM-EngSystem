using CRM_EngSystem_PostgreSQL.Data.DefaultData.ContactOrder;
using CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class ContactOrderEntityConfiguration : IEntityTypeConfiguration<ContactOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ContactOrderEntity> builder)
        {
            builder.HasKey(co => new { co.ContactId, co.OrderId });

            builder.HasOne(co => co.Contact)
                .WithMany(c => c.ContactOrders)
                .HasForeignKey(co => co.ContactId);

            builder.HasOne(co => co.Order)
                .WithMany(o => o.ContactOrders)
                .HasForeignKey(co => co.OrderId);

            builder.HasData(ContactOrderDefaultData.ContactOrders);
        }

    }
}
