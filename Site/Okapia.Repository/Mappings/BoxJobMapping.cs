using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class BoxJobMapping : IEntityTypeConfiguration<BoxJob>
    {
        public void Configure(EntityTypeBuilder<BoxJob> builder)
        {
            builder.ToTable("BoxJobs");
            builder.HasKey(x => new {x.BoxId, x.JobId});
            builder.HasOne(x => x.Box).WithMany(x => x.BoxJobs).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Job).WithMany(x => x.BoxJobs).OnDelete(DeleteBehavior.Cascade);
        }
    }
}