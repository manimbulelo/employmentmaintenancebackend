using EmployeeManagement.Core.Extensions;

namespace EmployeeManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEmployeeManagementCore(configuration);
        }
    }
}
