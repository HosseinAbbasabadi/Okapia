using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class JobPictureMapping : IEntityTypeConfiguration<JobPicture>
    {
        public void Configure(EntityTypeBuilder<JobPicture> builder)
        {
            builder.ToTable("JobPictures");
            builder.Property(e => e.JobPictureId).HasColumnName("JobPictureID");

            builder.Property(e => e.JobId).HasColumnName("JobID");

            builder.Property(e => e.JobPicturThumbUrl)
                .HasColumnName("JobPicturThumbURL")
                .HasMaxLength(400);

            builder.Property(e => e.JobPictureAlt).HasMaxLength(50);

            builder.Property(e => e.JobPictureSmallDescription).HasMaxLength(400);

            builder.Property(e => e.JobPictureTitle).HasMaxLength(100);

            builder.Property(e => e.JobPictureUrl)
                .HasColumnName("JobPictureURL")
                .HasMaxLength(400);

            builder.HasOne(d => d.Job)
                .WithMany(p => p.JobPictures)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPicture_Jobs");
        }
    }
}
