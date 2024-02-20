using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Persistence.Extensions;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Handlers.Impl;

namespace EmployeeManagement.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmployeeManagementCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEmployeeManagementPersistence(configuration);
            services.AddHandlers();
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeHandler, EmployeeHandler>();
        }
    }
}
