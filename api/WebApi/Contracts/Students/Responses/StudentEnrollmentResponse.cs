namespace WebApi.Contracts.Students.Responses;

public class StudentEnrollmentResponse
{
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string ProfessorName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
