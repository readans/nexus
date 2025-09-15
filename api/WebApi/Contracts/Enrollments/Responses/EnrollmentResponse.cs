namespace WebApi.Contracts.Enrollments.Responses;

public class EnrollmentResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public string StudentName { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string ProfessorName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; }
}
