using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class UserCardMapping : IEntityTypeConfiguration<UserCard>
    {
        public void Configure(EntityTypeBuilder<UserCard> builder)
        {
            builder.ToTable("UserCards");
            builder.HasKey(x => x.Id);
        }
    }
}
