namespace WebApi.Contracts.Students.Responses;

public class StudentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? PhotoUrl { get; set; }
    public int TotalCredits { get; set; }
}
