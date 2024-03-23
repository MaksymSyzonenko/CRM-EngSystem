using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;

namespace CRM_EngSystem_PostgreSQL.Data.DefaultData.Enterprise
{
    public static class EnterpriseDefaultData
    {
        public static List<EnterpriseEntity> Enterprises = new List<EnterpriseEntity>()
        {
            new EnterpriseEntity()
            {
                EnterpriseId = 1,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now
            },
            new EnterpriseEntity()
            {
                EnterpriseId = 2,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now

            },
            new EnterpriseEntity()
            {
                EnterpriseId = 3,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now
            },
            new EnterpriseEntity()
            {
                EnterpriseId = 4,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now
            }
        };
    }
}
