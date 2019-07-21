using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);
            builder.Property(x => x.EmployeeId).HasDefaultValueSql("NEXT VALUE FOR AccountReferenceIdSeq");

            builder.Property(e => e.EmployeeCreationDate).HasColumnType("datetime");

            builder.Property(e => e.EmployeeFirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.EmployeeLastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(x => x.EmployeeControllers).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Account).WithOne(x => x.Employee).HasForeignKey<Account>(x => x.ReferenceRecordId);
        }
    }
}