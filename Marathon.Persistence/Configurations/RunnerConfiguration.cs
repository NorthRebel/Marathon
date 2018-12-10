using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class RunnerConfiguration : IEntityTypeConfiguration<Runner>
    {
        public void Configure(EntityTypeBuilder<Runner> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("RunnerId");

            builder.Property(e => e.CountryId)
                .HasCharType(3)
                .HasColumnName("CountryCode");
            
            builder.Property(e => e.Photo)
                .HasVarbinaryType();

            builder.HasOne(e => e.Gender)
                .WithMany(p => p.Runners)
                .HasForeignKey(e => e.GenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Runners_Genders");

            builder.HasOne(e => e.Country)
                .WithMany(p => p.Runners)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Runners_Countries");
        }
    }
}
