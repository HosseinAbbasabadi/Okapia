using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class AuthInfoMapping : IEntityTypeConfiguration<AuthInfo>
    {
        public void Configure(EntityTypeBuilder<AuthInfo> builder)
        {
            builder.ToTable("AuthInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReferenceRecordId);
        }
    }
}
