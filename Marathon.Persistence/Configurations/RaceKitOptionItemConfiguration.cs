using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class RaceKitOptionItemConfiguration : IEntityTypeConfiguration<RaceKitOptionItem>
    {
        public void Configure(EntityTypeBuilder<RaceKitOptionItem> builder)
        {
            builder.HasKey(e => new
            {
                e.ItemId,
                e.OptionId
            }).ForSqlServerIsClustered(false);

            builder.Property(e => e.ItemId)
                .HasColumnName("RaceKitItemId");

            builder.Property(e => e.OptionId)
                .HasColumnName("RaceKitOptionId");

            builder.HasOne(e => e.Item)
                .WithMany(p => p.OptionItems)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionItems_Items");

            builder.HasOne(e => e.Option)
                .WithMany(p => p.OptionItems)
                .HasForeignKey(e => e.OptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionItems_Options");
        }
    }
}
