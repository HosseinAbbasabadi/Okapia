using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class PageCategoryMapping : IEntityTypeConfiguration<PageCategory>
    {
        public void Configure(EntityTypeBuilder<PageCategory> builder)
        {
            builder.ToTable("PageCategory");
            builder.Property(e => e.PageCategoryId).HasColumnName("PageCategoryID");

            builder.Property(e => e.PageCanonicalAddress).HasMaxLength(300);

            builder.Property(e => e.PageCategoryLinkToolTip).HasMaxLength(100);

            builder.Property(e => e.PageCategoryMetaDesccription).HasMaxLength(200);

            builder.Property(e => e.PageCategoryMetaTag).HasMaxLength(200);

            builder.Property(e => e.PageCategoryName).HasMaxLength(50);

            builder.Property(e => e.PageCategoryPageTittle).HasMaxLength(400);

            builder.Property(e => e.PageCategoryParentId).HasColumnName("PageCategoryParentID");

            builder.Property(e => e.PageCategoryRegisterDate).HasColumnType("datetime");

            builder.Property(e => e.PageCategoryRemoved301InsteadUrl)
                .HasColumnName("PageCategoryRemoved301InsteadURL")
                .HasMaxLength(200);

            builder.Property(e => e.PageCategorySeohead)
                .HasColumnName("PageCategorySEOHead")
                .HasMaxLength(400);

            builder.Property(e => e.PageCategorySlug).HasMaxLength(200);

            builder.Property(e => e.PageCategorySmallPictutre).HasMaxLength(400);

            builder.Property(e => e.PageCategorySmallPictutreAlt).HasMaxLength(400);

            builder.HasOne(d => d.PageCategoryParent)
                .WithMany(p => p.InversePageCategoryParent)
                .HasForeignKey(d => d.PageCategoryParentId)
                .HasConstraintName("FK_PageCategory_PageCategory");
        }
    }
}
