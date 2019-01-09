using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class RaceKitItemConfiguration : IEntityTypeConfiguration<RaceKitItem>
    {
        public void Configure(EntityTypeBuilder<RaceKitItem> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("RaceKitItemId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
