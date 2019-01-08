using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.Id)
                .HasCharType(3)
                .ValueGeneratedNever()
                .HasColumnName("CountryCode");

            builder.Property(e => e.Name)
                .HasColumnName("CountryName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Flag)
                .HasColumnName("CountryFlag")
                .HasVarbinaryType()
                .IsRequired();
        }
    }
}
