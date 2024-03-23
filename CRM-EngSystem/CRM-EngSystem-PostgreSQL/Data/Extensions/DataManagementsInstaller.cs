using CRM_EngSystem_PostgreSQL.Data.Managements.Order;
using Microsoft.Extensions.DependencyInjection;

namespace CRM_EngSystem_PostgreSQL.Data.Extensions
{
    public static class DataManagementsInstaller
    {
        public static IServiceCollection AddDataManagements(this IServiceCollection services)
        {
            services
                .AddScoped<IOrderManager, OrderManager>();

            return services;
        }
    }
}
