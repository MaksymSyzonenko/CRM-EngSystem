using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class WareHouseEntityConfiguration : IEntityTypeConfiguration<WareHouseEntity>
    {
        public void Configure(EntityTypeBuilder<WareHouseEntity> builder)
        {
            builder.HasKey(warehouse => warehouse.WareHouseId);
        }
    }
}
