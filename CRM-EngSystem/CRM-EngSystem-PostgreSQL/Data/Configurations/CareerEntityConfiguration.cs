using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using CRM_EngSystem_PostgreSQL.Data.DefaultData.Career;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class CareerEntityConfiguration : IEntityTypeConfiguration<CareerEntity>
    {
        public void Configure(EntityTypeBuilder<CareerEntity> builder)
        {
            builder.HasKey(career => career.CareerId);

            builder.HasOne(career => career.Contact)
                .WithMany(contact => contact.Careers)
                .HasForeignKey(career => career.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(career => career.Enterprise)
                .WithMany(enterprise => enterprise.Careers)
                .HasForeignKey(career => career.EnterpriseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(CareerDefaultData.Careers);
        }
    }
}
