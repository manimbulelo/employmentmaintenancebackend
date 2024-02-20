using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(person => person.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(person => person.LastName).HasMaxLength(128).IsRequired();

            builder.Property(person => person.BirthDate).HasColumnType("datetime");
        }
    }
}
