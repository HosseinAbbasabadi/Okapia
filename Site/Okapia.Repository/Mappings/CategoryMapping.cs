using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.CategoryMetaDesccription).HasMaxLength(200);

            builder.Property(e => e.CategoryMetaTag).HasMaxLength(200);

            builder.Property(e => e.CategoryPageTittle).HasMaxLength(400);

            builder.Property(e => e.CategoryParentId).HasColumnName("CategoryParentID");

            builder.Property(e => e.CategorySeohead)
                .HasColumnName("CategorySEOHead")
                .HasMaxLength(400);

            builder.Property(e => e.CategorySmallDescription).HasMaxLength(1000);

            builder.Property(e => e.CategoryThumbPicUrl)
                .HasColumnName("CategoryThumbPicURL")
                .HasMaxLength(1000);

            builder.Property(e => e.CatgoryName).HasMaxLength(400);

            builder.Property(e => e.Job).HasMaxLength(10);

            builder.Property(e => e.JobLinkTitle).HasMaxLength(100);

            builder.Property(e => e.RegisteringEmployeeId).HasColumnName("RegisteringEmployeeID");
        }
    }
}
