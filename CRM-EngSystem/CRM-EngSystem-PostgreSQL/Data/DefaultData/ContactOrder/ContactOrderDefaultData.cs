using CRM_EngSystem_PostgreSQL.Data.Entities.ContactOrder;

namespace CRM_EngSystem_PostgreSQL.Data.DefaultData.ContactOrder
{
    public static class ContactOrderDefaultData
    {
        public static List<ContactOrderEntity> ContactOrders = new()
        {
            new ContactOrderEntity()
            {
                OrderId = 1,
                ContactId = 1
            },
            new ContactOrderEntity()
            {
                OrderId = 1,
                ContactId = 2
            },
            new ContactOrderEntity()
            {
                OrderId = 1,
                ContactId = 3
            },
            new ContactOrderEntity()
            {
                OrderId = 2,
                ContactId = 4
            },
            new ContactOrderEntity()
            {
                OrderId = 2,
                ContactId = 5
            }
        };
    }
}
