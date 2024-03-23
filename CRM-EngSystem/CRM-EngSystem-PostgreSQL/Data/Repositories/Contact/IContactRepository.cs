using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Contact
{
    public interface IContactRepository : IRepository
    {
        Task AddContactDetailsAsync(ContactDetailsEntity entity);
        Task UpdateContactDetailsAsync(int currentEntityId, ContactDetailsEntity updatedEntity);
    }
}
