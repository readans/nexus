namespace WebApi.Contracts.Subjects.Requests;

public class CreateSubjectRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public int Credits { get; set; } = 3;
    public int MaxStudents { get; set; } = 30;
    public Guid ProfessorId { get; set; }
}
