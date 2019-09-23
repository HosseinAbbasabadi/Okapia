using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class LinkGroupMapping : IEntityTypeConfiguration<LinkGroup>
    {
        public void Configure(EntityTypeBuilder<LinkGroup> builder)
        {
            builder.ToTable("LinkGroups");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Links).WithOne(x => x.LinkGroup).HasForeignKey(x => x.LinkGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}