using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class SignUpStatusConfiguration : IEntityTypeConfiguration<SignUpStatus>
    {
        public void Configure(EntityTypeBuilder<SignUpStatus> builder)
        {
            builder.ToTable("RegistrationStatus");

            builder.Property(e => e.Id)
                .HasColumnName("RegistrationStatusId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("RegistrationStatus");
        }
    }
}
