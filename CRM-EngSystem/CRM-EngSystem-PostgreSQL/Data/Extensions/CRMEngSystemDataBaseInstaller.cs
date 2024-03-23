using CRM_EngSystem_PostgreSQL.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRM_EngSystem_PostgreSQL.Data.Extensions
{
    public static class CRMEngSystemDataBaseInstaller
    {
        public static IServiceCollection AddCRMEngSystemDataBasePostgreSQL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<CRMEngSystemDbContext>(options =>
                options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly("CRM-EngSystem-PostgreSQL")));

            return services;
        }
        public static IServiceCollection AddCRMEngSystemDataBaseSQLServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<CRMEngSystemDbContext>(options =>
                options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("CRM-EngSystem-PostgreSQL")));

            return services;
        }
    }
}
