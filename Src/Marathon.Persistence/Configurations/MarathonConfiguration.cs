using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    using Domain.Entities;

    public sealed class MarathonConfiguration : IEntityTypeConfiguration<Marathon>
    {
        public void Configure(EntityTypeBuilder<Marathon> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("MarathonId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.City)
                .HasMaxLength(80);

            builder.Property(e => e.CountryId)
                .HasCharType(3)
                .HasColumnName("CountryCode");

            builder.HasOne(e => e.Country)
                .WithMany(p => p.Marathons)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Marathons_Countries");
        }
    }
}
