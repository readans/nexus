namespace WebApi.Contracts.Students.Requests;

public class UpdateStudentRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? PhotoUrl { get; set; }
}
