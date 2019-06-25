using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain;

namespace Okapia.Repository.Mappings
{
    public class PageMapping : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {

            builder.Property(e => e.PageId).HasColumnName("PageID");

            builder.Property(e => e.PageCanonicalAddress).HasMaxLength(300);

            builder.Property(e => e.PageCategoryId).HasColumnName("PageCategoryID");

            builder.Property(e => e.PageMetaDesccription).HasMaxLength(200);

            builder.Property(e => e.PageMetaTag).HasMaxLength(200);

            builder.Property(e => e.PageRegisteringEmployeeId).HasColumnName("PageRegisteringEmployeeID");

            builder.Property(e => e.PageRegistrationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.PageRemoved301InsteadUrl)
                .HasColumnName("PageRemoved301InsteadURL")
                .HasMaxLength(200);

            builder.Property(e => e.PageSeohead)
                .HasColumnName("PageSEOHead")
                .HasMaxLength(400);

            builder.Property(e => e.PageSlug)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.PageSmallDescription).HasMaxLength(2000);

            builder.Property(e => e.PageTittle)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasOne(d => d.PageCategory)
                .WithMany(p => p.Page)
                .HasForeignKey(d => d.PageCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Page_PageCategory");
        }
    }
}
