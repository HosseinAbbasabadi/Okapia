using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class JobTransactionMapping : IEntityTypeConfiguration<JobTransactions>
    {
        public void Configure(EntityTypeBuilder<JobTransactions> builder)
        {
            builder.ToTable("JobTransactions");
            builder.Property(e => e.Ammount).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.LocalDateTime).HasColumnType("datetime");

            builder.Property(e => e.PanTrunc)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(e => e.Rrn).HasColumnName("RRN");

            builder.Property(e => e.TrAmmount).HasColumnType("decimal(18, 3)");
        }
    }
}
