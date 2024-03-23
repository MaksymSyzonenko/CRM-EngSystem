using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using CRM_EngSystem_PostgreSQL.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.User
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public UserRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is UserEntity user)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentUserId && updatedEntity is UserEntity updatedUser)
            {
                var currentUser = await _context.Users.FindAsync(currentUserId);
                if (currentUser != null)
                {
                    _context.Entry(currentUser).CurrentValues.SetValues(updatedUser);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is UserEntity user)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int userId ? await _context.Users
                    .Include(user => user.Contact)
                    .Include(user => user.Comments)
                    .FirstOrDefaultAsync(user => user.ContactId == userId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync()
            => await _context.Users
                .Include(user => user.Contact)
                .Include(user => user.Comments)
                .ToListAsync();

        public Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
        {
            throw new NotImplementedException();
        }



        //public async Task<IEnumerable<IEntity>> GetEntitiesByQueryAsync(Func<IEntity, bool> query)
        //{
        //    var users = await GetAllEntitiesAsync();

        //    if (query is Func<UserEntity, bool> userQuery)
        //        return users.Where(query);

        //    throw new BadQueryException(typeof(IEntity).Name);
        //}
    }
}
