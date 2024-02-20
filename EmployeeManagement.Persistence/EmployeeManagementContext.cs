using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EmployeeManagement");

            var currentAssembly = typeof(EmployeeManagementContext).Assembly;

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
