namespace WebApi.Contracts.Students.Requests;

public class CreateStudentRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? PhotoUrl { get; set; }
    public string? UID { get; set; }
}
