using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class MarathonSignUpConfiguration : IEntityTypeConfiguration<MarathonSignUp>
    {
        public void Configure(EntityTypeBuilder<MarathonSignUp> builder)
        {
            builder.ToTable("Registration");

            builder.Property(e => e.Id)
                .HasColumnName("RegistrationId");

            builder.Property(e => e.SignUpDate)
                .HasColumnType("RegistrationDateTime")
                .HasColumnType("datetime");

            builder.Property(e => e.SignUpStatusId)
                .HasColumnName("RegistrationStatusId");

            builder.Property(e => e.Cost)
                .DecimalPrecision(10, 2);

            builder.Property(e => e.SponsorshipTarget)
                .DecimalPrecision(10, 2);

            builder.HasOne(e => e.Runner)
                .WithMany(e => e.SignUps)
                .HasForeignKey(e => e.RunnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_Runners");

            builder.HasOne(e => e.RaceKitOption)
                .WithMany(p => p.SignUps)
                .HasForeignKey(e => e.RaceKitOptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_RaceKitOptions");

            builder.HasOne(e => e.SignUpStatus)
                .WithMany(p => p.SignUps)
                .HasForeignKey(e => e.SignUpStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_RegistrationStatuses");

            builder.HasOne(e => e.Charity)
                .WithMany(p => p.SignUps)
                .HasForeignKey(e => e.CharityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_Charities");
        }
    }
}
