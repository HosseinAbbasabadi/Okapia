using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain;

namespace Okapia.Repository.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeCreationDate).HasColumnType("datetime");

            builder.Property(e => e.EmployeeFirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.EmployeeLastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}