using Microsoft.EntityFrameworkCore;
using Okapia_DataCollector.Model;

namespace Okapia_DataCollector.Repository
{
    public partial class OkapiaContext : DbContext
    {
        public OkapiaContext()
        {
        }

        public OkapiaContext(DbContextOptions<OkapiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobTransaction> JobTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
            modelBuilder.Entity<JobTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ammount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LocalDateTime).HasColumnType("datetime");

                entity.Property(e => e.PanTrunc)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Rrn).HasColumnName("RRN");

                entity.Property(e => e.TrAmmount).HasColumnType("decimal(18, 3)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}