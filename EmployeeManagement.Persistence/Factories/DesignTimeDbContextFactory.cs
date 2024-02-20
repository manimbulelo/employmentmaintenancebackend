using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EmployeeManagement.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmployeeManagementContext>
    {
        public EmployeeManagementContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EmployeeManagementContext>();
            var connectionString = configuration.GetConnectionString(Constants.ConnectionStringName);
            builder.UseSqlServer(connectionString);

            return new EmployeeManagementContext(builder.Options);
        }
    }
}
