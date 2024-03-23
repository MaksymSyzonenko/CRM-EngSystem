using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Exceptions;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Career;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Comment;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Contact;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.User;
using CRM_EngSystem_PostgreSQL.Data.Repositories.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Core;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Factory
{
    public sealed class RepositoryFactory : IRepositoryFactory
    {
        public IRepository Instantiate<IEntity>(CRMEngSystemDbContext context)
        {
            return typeof(IEntity).Name switch
            {
                nameof(UserEntity) => new UserRepository(context),
                nameof(ContactEntity) => new ContactRepository(context),
                nameof(EnterpriseEntity) => new EnterpriseRepository(context),
                nameof(OrderEntity) => new OrderRepository(context),
                nameof(CommentEntity) => new CommentRepository(context),
                nameof(CareerEntity) => new CareerRepository(context),
                nameof(WareHouseEntity) => new WareHouseRepository(context),
                _ => throw new UnsupportedRepositoryTypeException(typeof(IEntity).Name)
            };
        }
    }
}
