using Marathon.Domain.Entities;
using Marathon.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Id)
                .HasCharType(6)
                .ValueGeneratedNever()
                .HasColumnName("EventId");

            builder.Property(e => e.Name)
                .HasColumnName("EventName")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.StartDate)
                .HasColumnName("StartDateTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Cost)
                .DecimalPrecision(10,2);

            builder.HasOne(e => e.EventType)
                .WithMany(p => p.Events)
                .HasForeignKey(e => e.EventTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Events_EventTypes");

            builder.HasOne(e => e.Marathon)
                .WithMany(p => p.Events)
                .HasForeignKey(e => e.MarathonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Events_Marathons");
        }
    }
}
