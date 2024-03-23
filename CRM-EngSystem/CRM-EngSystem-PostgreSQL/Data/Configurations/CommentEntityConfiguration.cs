using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(comment => comment.CommentId);

            builder.HasOne(comment => comment.Author)
               .WithMany(author => author.Comments)
               .HasForeignKey(comment => comment.AuthorId);
            
            builder.HasOne(comment => comment.RecipientContact)
                .WithMany(contact => contact.Comments)
                .HasForeignKey(comment => comment.RecipientContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(comment => comment.RecipientEnterprise)
                .WithMany(enterprise => enterprise.Comments)
                .HasForeignKey(comment => comment.RecipientEnterpriseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(comment => comment.RecipientOrder)
                .WithMany(order => order.Comments)
                .HasForeignKey(comment => comment.RecipientOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
