using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class GroupMapping : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.HasKey(e => e.GroupId);

            builder.Property(e => e.GroupCreationDate).HasColumnType("datetime");

            builder.Property(e => e.GroupDescription).HasMaxLength(500);

            builder.Property(e => e.GroupName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
