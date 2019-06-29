using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain;

namespace Okapia.Repository.Mappings
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

            builder.HasOne(d => d.Province)
                .WithMany(p => p.City)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_City_Province");
        }
    }
}