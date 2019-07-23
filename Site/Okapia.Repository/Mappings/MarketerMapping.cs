using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class MarketerMapping : IEntityTypeConfiguration<Marketer>
    {
        public void Configure(EntityTypeBuilder<Marketer> builder)
        {
            builder.ToTable("Marketers");
            builder.HasKey(x => x.MarketerId);
        }
    }
}