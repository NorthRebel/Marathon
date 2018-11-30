using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("VolunteerId");

            builder.Property(e => e.FirstName)
                .HasMaxLength(80);

            builder.Property(e => e.LastName)
                .HasMaxLength(80);

            builder.Property(e => e.CountryId)
                .HasCharType(3)
                .HasColumnName("CountryCode");

            builder.HasOne(e => e.Gender)
                .WithMany(p => p.Volunteers)
                .HasForeignKey(e => e.GenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Volunteers_Genders");


            builder.HasOne(e => e.Country)
                .WithMany(p => p.Volunteers)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Volunteers_Countries");
        }
    }
}
