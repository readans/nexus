namespace WebApi.Contracts.Professors.Responses;

public class ProfessorWithSubjectsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<SubjectSummaryResponse> Subjects { get; set; } = new();
}
