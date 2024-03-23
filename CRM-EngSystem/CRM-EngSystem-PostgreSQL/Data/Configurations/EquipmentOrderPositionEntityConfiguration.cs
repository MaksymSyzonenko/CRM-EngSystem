using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class EquipmentOrderPositionEntityConfiguration : IEntityTypeConfiguration<EquipmentOrderPositionEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentOrderPositionEntity> builder)
        {
            builder.HasKey(equipment => equipment.EquipmentCatalogPositionId);

            builder.HasOne(equipment => equipment.Order)
                .WithMany(order => order.EquipmentOrderPositions)
                .HasForeignKey(equipment => equipment.OrderId);
        }
    }
}
