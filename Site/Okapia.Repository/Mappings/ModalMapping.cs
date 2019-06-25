using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class ModalMapping : IEntityTypeConfiguration<Modals>
    {
        public void Configure(EntityTypeBuilder<Modals> builder)
        {
            builder.HasKey(e => e.ModalId);

            builder.Property(e => e.ModalCreationDate).HasColumnType("datetime");

            builder.Property(e => e.ModalEndDate).HasColumnType("datetime");

            builder.Property(e => e.ModalMessage)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.ModalPageLink).HasMaxLength(1000);

            builder.Property(e => e.ModalPic).HasMaxLength(50);

            builder.Property(e => e.ModalStartDate).HasColumnType("datetime");

            builder.Property(e => e.ModalTtitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.ModalGroup)
                .WithMany(p => p.Modals)
                .HasForeignKey(d => d.ModalGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modals_Groups");
        }
    }
}