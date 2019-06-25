using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain;

namespace Okapia.Repository.Mappings
{
    public class JobRelationMapping : IEntityTypeConfiguration<JobRelation>
    {
        public void Configure(EntityTypeBuilder<JobRelation> builder)
        {
            builder.Property(e => e.JobRelationId).HasColumnName("JobRelationID");

            builder.Property(e => e.JobId).HasColumnName("JobID");

            builder.Property(e => e.RelatedId).HasColumnName("RelatedID");

            //builder.HasOne(d => d.Job)
            //    .WithMany(p => p.jobre)
            //    .HasForeignKey(d => d.JobId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_JobRelation_Jobs");

            //builder.HasOne(d => d.Related)
            //    .WithMany(p => p.JobRelationRelated)
            //    .HasForeignKey(d => d.RelatedId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_JobRelation_Jobs1");
        }
    }
}
