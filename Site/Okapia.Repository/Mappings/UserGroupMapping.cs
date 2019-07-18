using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class UserGroupMapping : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(bc => new {bc.UserId, bc.GroupId});
            builder.HasOne(x => x.User).WithMany(x => x.UserGroups).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Group).WithMany(x => x.UserGroups).HasForeignKey(x => x.GroupId);
        }
    }
}
