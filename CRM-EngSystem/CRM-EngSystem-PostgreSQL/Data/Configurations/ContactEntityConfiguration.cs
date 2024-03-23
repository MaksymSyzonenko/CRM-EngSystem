using CRM_EngSystem_PostgreSQL.Data.DefaultData.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.HasKey(contact => contact.ContactId);

            builder.HasOne(contact => contact.User)
                .WithOne(user => user.Contact)
                .HasForeignKey<UserEntity>(user => user.ContactId)
                .IsRequired();

            builder.HasOne(contact => contact.Details)
                .WithOne(details => details.Contact)
                .HasForeignKey<ContactDetailsEntity>(details => details.ContactId)
                .IsRequired();

            builder.HasOne(contact => contact.Enterprise)
                .WithMany(enterprise => enterprise.Contacts)
                .HasForeignKey(contact => contact.EnterpriseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(ContactDefaultData.Contacts);
        }
    }
}
