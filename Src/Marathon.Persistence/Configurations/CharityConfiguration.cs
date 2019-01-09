using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class CharityConfiguration : IEntityTypeConfiguration<Charity>
    {
        public void Configure(EntityTypeBuilder<Charity> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("CharityId");

            builder.Property(e => e.Name)
                .HasColumnName("CharityName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasColumnName("CharityDescription")
                .HasMaxLength(2000);

            builder.Property(e => e.Logo)
                .HasColumnName("CharityLogo");
        }
    }
}
