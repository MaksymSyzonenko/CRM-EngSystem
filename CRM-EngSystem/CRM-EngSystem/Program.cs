using CRM_EngSystem_PostgreSQL.Data.Extensions;
using CRM_EngSystem.AutoMappers.Enterprise;
using CRM_EngSystem.AutoMappers.Contact;
using CRM_EngSystem.AutoMappers.Order;

namespace CRM_EngSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = configurationBuilder.Build();
            string SQLServerConnection = "SQLServerConnection";
            string PostgreSQLConnection = "PostgreSQLConnection";
            var connectionString = configuration.GetConnectionString(SQLServerConnection);
            builder.Services.AddCRMEngSystemDataBaseSQLServer(connectionString!);
            builder.Services.AddAutoMapper(typeof(EnterpriseDetailsEntityProfile), typeof(ContactDetailsEntityProfile), typeof(OrderEntityProfile));
            builder.Services.AddAutoMappers()
                            .AddDataRepositories()
                            .AddDataManagements();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}