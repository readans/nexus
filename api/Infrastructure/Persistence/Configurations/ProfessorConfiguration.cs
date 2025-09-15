using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasIndex(e => e.Email).IsUnique();

        entity.HasMany(e => e.Subjects)
            .WithOne(e => e.Professor)
            .HasForeignKey(e => e.ProfessorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
