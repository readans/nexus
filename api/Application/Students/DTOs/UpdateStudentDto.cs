namespace Application.Students.DTOs;

public class UpdateStudentDto
{
    public string Name { get; set;  }
    public string Email { get; set; }
    public string? PhotoUrl { get; set; }
    public int TotalCredits { get; set; } = 9;
    public string? UID { get; set; }
}