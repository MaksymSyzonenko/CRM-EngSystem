using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class EquipmentWareHousePositionEntityConfiguration : IEntityTypeConfiguration<EquipmentWareHousePositionEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentWareHousePositionEntity> builder)
        {
            builder.HasKey(equipment => equipment.EquipmentCatalogPositionId);

            builder.HasOne(equipment => equipment.WareHouse)
                .WithMany(warehouse => warehouse.EquipmentWareHousePositions)
                .HasForeignKey(equipment => equipment.WareHouseId);
        }
    }
}
