using Domain.Abstractions;

namespace Domain.Entities;

public class Professor: BaseEntity<Guid>
{
    public string Name { get; set;  }
    public string Email { get; set; }
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}