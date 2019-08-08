using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class PageMapping : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");

            builder.HasKey(x => x.PageId);

            //builder.HasMany(x => x.PageComments).WithOne(x => x.).HasForeignKey(x => x.PageId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.PageCategory)
                .WithMany(p => p.Pages)
                .HasForeignKey(d => d.PageCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}