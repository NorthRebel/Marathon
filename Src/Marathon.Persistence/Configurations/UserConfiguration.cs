using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FirstName)
                .HasMaxLength(80);

            builder.Property(e => e.LastName)
                .HasMaxLength(80);

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.HasOne(e => e.UserType)
                .WithMany(p => p.Users)
                .HasForeignKey(e => e.UserTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Roles");

            builder.HasOne(u => u.Runner)
                .WithOne(r => r.User)
                .HasForeignKey<Runner>(r => r.UserId)
                .HasConstraintName("FK_User_Runner");
        }
    }
}
