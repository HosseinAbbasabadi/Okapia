using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class JobRequestMapping : IEntityTypeConfiguration<JobRequest>
    {
        public void Configure(EntityTypeBuilder<JobRequest> builder)
        {
            builder.ToTable("JobRequests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TrackingNumber).HasDefaultValueSql("NEXT VALUE FOR TrackingNumberSeq");
        }
    }
}
