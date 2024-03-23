using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Builder.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Comment
{
    public sealed class CommentRepository : ICommentRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public CommentRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is CommentEntity comment)
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentCommentId && updatedEntity is CommentEntity updatedComment)
            {
                var currentComment = await _context.Comments.FindAsync(currentCommentId);
                if (currentComment != null)
                {
                    _context.Entry(currentComment).CurrentValues.SetValues(updatedComment);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is CommentEntity comment)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int commentId ? await _context.Comments
                    .Include(comment => comment.Author)
                    .Include(comment => comment.RecipientContact)
                    .Include(comment => comment.RecipientEnterprise)
                    .Include(comment => comment.RecipientOrder)
                    .FirstOrDefaultAsync(comment => comment.CommentId == commentId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync()
            => await _context.Comments
                .Include(comment => comment.Author)
                .Include(comment => comment.RecipientContact)
                .Include(comment => comment.RecipientEnterprise)
                .Include(comment => comment.RecipientOrder)
                .ToListAsync();

        public Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
