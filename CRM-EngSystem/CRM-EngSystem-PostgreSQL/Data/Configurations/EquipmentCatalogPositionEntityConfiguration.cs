using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class EquipmentCatalogPositionEntityConfiguration : IEntityTypeConfiguration<EquipmentCatalogPositionEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentCatalogPositionEntity> builder)
        {
            builder.HasKey(equipment => equipment.EquipmentCatalogPositionId);

            builder.HasOne(equipment => equipment.EquipmentOrderPosition)
                .WithOne(equipment => equipment.EquipmentCatalogPosition)
                .HasForeignKey<EquipmentOrderPositionEntity>(equipment => equipment.EquipmentCatalogPositionId)
                .IsRequired();

            builder.HasOne(equipment => equipment.EquipmentWareHousePosition)
                .WithOne(equipment => equipment.EquipmentCatalogPosition)
                .HasForeignKey<EquipmentWareHousePositionEntity>(equipment => equipment.EquipmentCatalogPositionId)
                .IsRequired();
        }
    }
}
