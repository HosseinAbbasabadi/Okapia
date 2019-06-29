using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class PageCommentMapping : IEntityTypeConfiguration<PageComments>
    {
        public void Configure(EntityTypeBuilder<PageComments> builder)
        {
            builder.ToTable("PageComments");
            builder.HasKey(e => e.PageCommentId);

            builder.Property(e => e.PageCommentId)
                .HasColumnName("PageCommentID")
                .ValueGeneratedNever();

            builder.Property(e => e.CommentDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CommentPageUrl)
                .HasColumnName("CommentPageURL")
                .HasMaxLength(200);

            builder.Property(e => e.CommentTitle).HasMaxLength(200);

            builder.Property(e => e.CommentUserId).HasColumnName("CommentUserID");

            builder.Property(e => e.CommnetText).HasMaxLength(4000);

            builder.Property(e => e.PageCommentConfiringUserId).HasColumnName("PageCommentConfiringUserID");

            builder.Property(e => e.PageCommentConfirmDate).HasColumnType("datetime");

            builder.Property(e => e.PageId).HasColumnName("PageID");

            builder.HasOne(d => d.Page)
                .WithMany(p => p.PageComments)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PageComments_Page");
        }
    }
}
