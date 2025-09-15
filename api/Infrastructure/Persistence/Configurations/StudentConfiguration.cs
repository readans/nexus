using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.PhotoUrl)
            .HasMaxLength(250);

        entity.Property(e => e.TotalCredits)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(e => e.UID)
            .HasMaxLength(50);

        entity.HasIndex(e => e.Email).IsUnique();
        entity.HasIndex(e => e.UID).IsUnique();

        entity.HasMany(e => e.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
