using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class JobMapping : IEntityTypeConfiguration<Jobs>
    {
        public void Configure(EntityTypeBuilder<Jobs> builder)
        {
            builder.HasKey(e => e.JobId);

            builder.Property(e => e.JobId).HasColumnName("JobID");

            builder.Property(e => e.InstagramUrl).HasMaxLength(200);

            builder.Property(e => e.JobAccountNumber).HasMaxLength(400);

            builder.Property(e => e.JobAddress).HasMaxLength(1000);

            builder.Property(e => e.JobCanonicalAddress).HasMaxLength(300);

            builder.Property(e => e.JobCityId).HasColumnName("JobCityID");

            builder.Property(e => e.JobContactTitile).HasMaxLength(400);

            builder.Property(e => e.JobContractNumber).HasMaxLength(10);

            builder.Property(e => e.JobEmailAddress).HasMaxLength(200);

            builder.Property(e => e.JobManagerFirstName).HasMaxLength(60);

            builder.Property(e => e.JobManagerLastName).HasMaxLength(60);

            builder.Property(e => e.JobMap).HasMaxLength(1000);

            builder.Property(e => e.JobMetaDesccription).HasMaxLength(200);

            builder.Property(e => e.JobMetaTag).HasMaxLength(200);

            builder.Property(e => e.JobMobile1).HasMaxLength(20);

            builder.Property(e => e.JobMobile2).HasMaxLength(50);

            builder.Property(e => e.JobName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.JobPageTittle).HasMaxLength(400);

            builder.Property(e => e.JobPosNameNumber).HasMaxLength(400);

            builder.Property(e => e.JobProvienceId).HasColumnName("JobProvienceID");

            builder.Property(e => e.JobRemoved301InsteadUrl)
                .HasColumnName("JobRemoved301InsteadURL")
                .HasMaxLength(200);

            builder.Property(e => e.JobSeohead)
                .HasColumnName("JobSEOHead")
                .HasMaxLength(400);

            builder.Property(e => e.JobSlug)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.JobSmallDescription).HasMaxLength(2000);

            builder.Property(e => e.JobTel1).HasMaxLength(20);

            builder.Property(e => e.JobTel2).HasMaxLength(20);

            builder.Property(e => e.MarketerId).HasColumnName("MarketerID");

            builder.Property(e => e.RegisteringEmployerId).HasColumnName("RegisteringEmployerID");

            builder.Property(e => e.TelegramUrl).HasMaxLength(200);

            builder.Property(e => e.WebSiteUrl).HasMaxLength(200);
        }
    }
}