using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.DefaultData.Contact;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class ContactDetailsEntityConfiguration : IEntityTypeConfiguration<ContactDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<ContactDetailsEntity> builder)
        {
            builder.HasKey(details => details.ContactId);

            builder.HasData(ContactDetailsDefaultData.ContactsDetails);
        }
    }
}
