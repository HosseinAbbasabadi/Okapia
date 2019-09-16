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

            builder.Property(e => e.CategoryParentId).HasColumnName("CategoryParentId");

            builder.Property(e => e.CategorySeohead)
                .HasColumnName("CategorySEOHead")
                .HasMaxLength(400);

            builder.Property(e => e.CategorySmallDescription).HasMaxLength(1000);

            builder.Property(e => e.CategoryThumbPicUrl)
                .HasColumnName("CategoryThumbPicURL")
                .HasMaxLength(1000);

            builder.Property(e => e.CategoryName).HasMaxLength(400);

            builder.Property(e => e.JobLinkTitle).HasMaxLength(100);

            builder.Property(e => e.RegisteringEmployeeId).HasColumnName("RegisteringEmployeeId");

            builder.HasOne(x => x.Parent).WithMany(x => x.Childs).HasForeignKey(x => x.CategoryParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}