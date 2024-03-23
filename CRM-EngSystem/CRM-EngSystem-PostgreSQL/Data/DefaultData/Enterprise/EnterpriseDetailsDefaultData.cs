using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;

namespace CRM_EngSystem_PostgreSQL.Data.DefaultData.Enterprise
{
    public static class EnterpriseDetailsDefaultData
    {
        public static List<EnterpriseDetailsEntity> EnterprisesDetails = new()
        {
            new EnterpriseDetailsEntity()
            {
                EnterpriseId = 1,
                NameUA = "АктивПром",
                NameEN = "ActiveProm",
                OwnershipFormUA = "Товариство з обмеженою відповідальністю",
                OwnershipFormEN = "Limited Liability Company",
                IndustryBranch = "Машинобудування",
                Franchise = "Відсутня",
                Country = "Україна",
                City = "Київ",
                Region = "Київська область",
                PostalCode = "03056",
                Street = "вул. Січових Стрільців, 25"
            },
            new EnterpriseDetailsEntity()
            {
                EnterpriseId = 2,
                NameUA = "Глобус",
                NameEN = "Globus",
                OwnershipFormUA = "Акціонерне товариство",
                OwnershipFormEN = "Joint-stock company",
                IndustryBranch = "Торгівля",
                Franchise = "Відсутня",
                Country = "Україна",
                City = "Львів",
                Region = "Львівська область",
                PostalCode = "79000",
                Street = "вул. Шевченка, 20"
            },
            new EnterpriseDetailsEntity()
            {
                EnterpriseId = 3,
                NameUA = "ТехноСервіс",
                NameEN = "TechnoService",
                OwnershipFormUA = "Приватне підприємство",
                OwnershipFormEN = "Private Enterprise",
                IndustryBranch = "Інформаційні технології",
                Franchise = "Відсутня",
                Country = "Україна",
                City = "Харків",
                Region = "Харківська область",
                PostalCode = "61000",
                Street = "пр. Науки, 14"
            },
            new EnterpriseDetailsEntity()
            {
                EnterpriseId = 4,
                NameUA = "Будівельник",
                NameEN = "Budivelnyk",
                OwnershipFormUA = "Колективне підприємство",
                OwnershipFormEN = "Collective Enterprise",
                IndustryBranch = "Будівництво",
                Franchise = "Відсутня",
                Country = "Україна",
                City = "Одеса",
                Region = "Одеська область",
                PostalCode = "65000",
                Street = "вул. Дерибасівська, 15"
            }

        };
    }
}
