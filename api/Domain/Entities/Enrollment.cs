using Domain.Abstractions;

namespace Domain.Entities;

public class Enrollment: BaseEntity<Guid>
{
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
        
    public Guid SubjectId { get; set; }

    public Subject? Subject { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; }
}