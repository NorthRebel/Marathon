using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Configurations
{
    public sealed class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("Role");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("RoleId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("RoleName");
        }
    }
}
