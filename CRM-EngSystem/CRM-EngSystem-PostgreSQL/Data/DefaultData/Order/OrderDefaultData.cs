using CRM_EngSystem_PostgreSQL.Data.DefaultData.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Order;

namespace CRM_EngSystem_PostgreSQL.Data.DefaultData.Order
{
    public static class OrderDefaultData
    {
        public static List<OrderEntity> Orders = new()
        {
            new OrderEntity()
            {
                OrderId = 1,
                Status = Enums.OrderStatusValue.Active,
                DateTimeActiveStatusStart = DateTime.Now,
                Priority = Enums.PriorityValue.Low,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now,
                InitiatorId = 1,
                CustomerId = 1,
            },
            new OrderEntity()
            {
                OrderId = 2,
                Status = Enums.OrderStatusValue.Active,
                DateTimeActiveStatusStart = DateTime.Now,
                Priority = Enums.PriorityValue.Low,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now,
                InitiatorId = 2,
                CustomerId = 2,
            },
            new OrderEntity()
            {
                OrderId = 3,
                Status = Enums.OrderStatusValue.Active,
                DateTimeActiveStatusStart = DateTime.Now,
                Priority = Enums.PriorityValue.Low,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now,
                InitiatorId = 3,
                CustomerId = 3,
            }
        };
    }
}
