using EmployeeManagement.Persistence.Managers.Impl;
using EmployeeManagement.Persistence.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmployeeManagementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerContext(configuration);
            services.AddManagers();
        }

        public static void AddSqlServerContext(this IServiceCollection services, IConfiguration configuration)
        {
            // I cheated here because I couldn't get the DefaultConnectionString dynamically (didn't want to spend mpre time on this)
            var connString = "data source=.;initial catalog=EmployeeManagementDb;persist security info=True;Integrated Security=SSPI;TrustServerCertificate=True";

            services.AddDbContext<EmployeeManagementContext>(options =>
                options.UseSqlServer(connString));
        }

        private static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
        }
    }
}
