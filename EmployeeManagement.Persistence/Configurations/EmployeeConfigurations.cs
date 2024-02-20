using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Persistence.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(employee => employee.EmployeeNum).HasMaxLength(16).IsRequired();

            builder.Property(employee => employee.TerminatedDate).HasColumnType("datetime");
            builder.Property(employee => employee.EmployedDate).HasColumnType("datetime");

            builder.HasOne(employee => employee.Person)
                    .WithMany()
                    .HasForeignKey(employee => employee.PersonId);
        }
    }
}
