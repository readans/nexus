using Domain.Abstractions;

namespace Domain.Entities;

public class Subject: BaseEntity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public int Credits { get; set; }
    public int MaxStudents { get; set; }
    public Guid ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}