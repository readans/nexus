namespace Application.Subjects.DTOs;

public class SubjectStudentsDto
{
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public List<StudentInSubjectDto> Students { get; set; } = new();
}