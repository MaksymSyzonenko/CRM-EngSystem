using CRM_EngSystem_PostgreSQL.Data.Entities.Career;
using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Entities.Comment;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.User;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Order;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRM_EngSystem_PostgreSQL.Data.Core
{
    public sealed class CRMEngSystemDbContext : DbContext
    {
        public CRMEngSystemDbContext(DbContextOptions<CRMEngSystemDbContext> options)
        : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ContactDetailsEntity> ContactsDetails { get; set; }
        public DbSet<CareerEntity> Careers { get; set; }
        public DbSet<EnterpriseEntity> Enterprises { get; set; }
        public DbSet<EnterpriseDetailsEntity> EnterprisesDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ContactOrderEntity> ContactOrders { get; set; }
        public DbSet<EquipmentCatalogPositionEntity> EquipmentCatalogPositions { get; set; }
        public DbSet<EquipmentOrderPositionEntity> EquipmentOrderPositions { get; set; }
        public DbSet<WareHouseEntity> WareHouses { get; set; }
        public DbSet<EquipmentWareHousePositionEntity> EquipmentWareHousePositions { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
