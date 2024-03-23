using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using System.Linq;
using CRM_EngSystem_PostgreSQL.Data.Builder.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Contact
{
    public sealed class ContactRepository : IContactRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public ContactRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is ContactEntity contact)
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentContactId && updatedEntity is ContactEntity updatedContact)
            {
                var currentContact = await _context.Contacts.FindAsync(currentContactId);
                if (currentContact != null)
                {
                    _context.Entry(currentContact).CurrentValues.SetValues(updatedContact);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is ContactEntity contact)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int contactId ? await _context.Contacts
                    .Include(contact => contact.Details)
                    .Include(contact => contact.Enterprise)
                    .Include(contact => contact.ContactOrders)!
                        .ThenInclude(contactorder => contactorder.Order)
                    .Include(contact => contact.Comments)
                    .Include(contact => contact.Careers)
                    .FirstOrDefaultAsync(contact => contact.ContactId == contactId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
            => await new EntityLoadDataBuilder<ContactEntity>(_context.Contacts.AsQueryable(), options)
                    .Include(contact => contact.Details)
                    .Include(contact => contact.Enterprise)
                    .DeepInclude(contact => contact.ContactOrders!, contactorder => contactorder.Order)
                    .Include(contact => contact.Comments!)
                    .Include(contact => contact.Careers)
                    .ExecuteAsync();

        //ContactDetails Methods
        public async Task AddContactDetailsAsync(ContactDetailsEntity entity)
        {
            if (entity != null)
            {
                await _context.ContactsDetails.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateContactDetailsAsync(int currentEntityId, ContactDetailsEntity updatedEntity)
        {
            if (updatedEntity != null && (await _context.ContactsDetails.FindAsync(currentEntityId)) is { } currentContactDetails)
            {
                _context.Entry(currentContactDetails).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
