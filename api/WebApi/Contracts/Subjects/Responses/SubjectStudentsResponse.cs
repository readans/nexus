namespace WebApi.Contracts.Subjects.Responses;

public class SubjectStudentsResponse
{
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public List<StudentInSubjectResponse> Students { get; set; } = new();
}
