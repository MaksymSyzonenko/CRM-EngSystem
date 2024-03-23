using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using Microsoft.Extensions.DependencyInjection;

namespace CRM_EngSystem_PostgreSQL.Data.Extensions
{
    public static class AutoMappersInstaller
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(EquipmentOrderPositionEntity));

            return services;
        }
    }
}
