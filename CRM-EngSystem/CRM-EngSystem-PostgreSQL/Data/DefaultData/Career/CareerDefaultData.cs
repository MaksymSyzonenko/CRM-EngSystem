using CRM_EngSystem_PostgreSQL.Data.Entities.Career;

namespace CRM_EngSystem_PostgreSQL.Data.DefaultData.Career
{
    public static class CareerDefaultData
    {
        public static List<CareerEntity> Careers = new()
        {
            new CareerEntity()
            {
                CareerId = 1,
                Position = "Менеджер",
                DateTimeStart = DateTime.Now,
                DateTimeEnd = new DateTime(1,1,1),
                ContactId = 1,
                EnterpriseId = 1,
            },
            new CareerEntity()
            {
                CareerId = 2,
                Position = "Грузчик",
                DateTimeStart = new DateTime(2007,12,12),
                DateTimeEnd = DateTime.Now,
                ContactId = 1,
                EnterpriseId = 1,
            },
            new CareerEntity()
            {
                CareerId = 3,
                Position = "Менеджер",
                DateTimeStart = new DateTime(2004,10,2),
                DateTimeEnd = new DateTime(2007,12,12),
                ContactId = 1,
                EnterpriseId = 3,
            }
        };
    }
}
