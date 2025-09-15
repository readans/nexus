using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Description)
            .HasMaxLength(500);

        entity.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(20);

        entity.Property(e => e.Credits)
            .IsRequired()
            .HasDefaultValue(3);

        entity.Property(e => e.MaxStudents)
            .IsRequired()
            .HasDefaultValue(30);

        entity.HasIndex(e => e.Code).IsUnique();
        
        entity.HasOne(e => e.Professor)
            .WithMany(e => e.Subjects)
            .HasForeignKey(e => e.ProfessorId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(e => e.Enrollments)
            .WithOne(e => e.Subject)
            .HasForeignKey(e => e.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}