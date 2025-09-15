namespace WebApi.Contracts.Subjects.Responses;

public class SubjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int Credits { get; set; }
    public int MaxStudents { get; set; }
    public string ProfessorName { get; set; }
}
