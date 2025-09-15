using Domain.Abstractions;

namespace Domain.Entities;

public class Student: BaseEntity<Guid>
{
    public string Name { get; set;  }
    public string Email { get; set; }
    public string? PhotoUrl { get; set; }
    public int TotalCredits { get; set; }
    public string? UID { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}