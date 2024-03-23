using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.ContactId);
        }
    }
}
