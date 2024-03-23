using CRM_EngSystem_PostgreSQL.Data.Repositories.Career;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Comment;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Contact;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Factory;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.User;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;
using Microsoft.Extensions.DependencyInjection;

namespace CRM_EngSystem_PostgreSQL.Data.Extensions
{
    public static class DataRepositoriesInstaller
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IContactRepository, ContactRepository>()
                .AddScoped<IEnterpriseRepository, EnterpriseRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<ICareerRepository, CareerRepository>();

            services
                .AddSingleton<IRepositoryFactory, RepositoryFactory>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
