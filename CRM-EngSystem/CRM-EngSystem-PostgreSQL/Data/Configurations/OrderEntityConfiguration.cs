using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.DefaultData.Order;

namespace CRM_EngSystem_PostgreSQL.Data.Configurations
{
    public sealed class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(order => order.OrderId);

            

            builder.HasData(OrderDefaultData.Orders);
        }
    }
}
