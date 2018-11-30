using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class SponsorshipConfiguration : IEntityTypeConfiguration<Sponsorship>
    {
        public void Configure(EntityTypeBuilder<Sponsorship> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("SponsorshipId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("SponsorName");

            builder.Property(e => e.SignUpId)
                .HasColumnName("RegistrationId");

            builder.Property(e => e.Amount)
                .DecimalPrecision(10, 2);

            builder.HasOne(e => e.SignUp)
                .WithMany(p => p.Sponsorships)
                .HasForeignKey(e => e.SignUp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Sponsorships_Registrations");
        }
    }
}
