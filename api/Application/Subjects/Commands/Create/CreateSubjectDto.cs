namespace Application.Subjects.Commands.Create;

public class CreateSubjectDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public int Credits { get; set; }
    public int MaxStudents { get; set; }
    public Guid ProfessorId { get; set; }
}