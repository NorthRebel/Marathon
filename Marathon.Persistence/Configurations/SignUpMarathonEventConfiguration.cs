using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class SignUpMarathonEventConfiguration : IEntityTypeConfiguration<SignUpMarathonEvent>
    {
        public void Configure(EntityTypeBuilder<SignUpMarathonEvent> builder)
        {
            builder.ToTable("RegistrationEventId");

            builder.Property(e => e.SignUpId)
                .HasColumnName("RegistrationId");

            builder.Property(e => e.EventId)
                .HasCharType(6);

            builder.HasOne(e => e.SignUp)
                .WithMany(p => p.SignUpMarathonEvents)
                .HasForeignKey(e => e.SignUpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RegistrationEvents_Registrations");

            builder.HasOne(e => e.Event)
                .WithMany(p => p.SignUpMarathonEvents)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RegistrationEvents_Events");
        }
    }
}
