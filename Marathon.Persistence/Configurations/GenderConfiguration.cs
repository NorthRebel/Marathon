using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("GenderId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("GenderName");
        }
    }
}
