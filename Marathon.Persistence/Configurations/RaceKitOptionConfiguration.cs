using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class RaceKitOptionConfiguration : IEntityTypeConfiguration<RaceKitOption>
    {
        public void Configure(EntityTypeBuilder<RaceKitOption> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("RaceKitOptionId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("RaceKitOption");

            builder.Property(e => e.Cost)
                .DecimalPrecision(10, 2);
        }
    }
}
