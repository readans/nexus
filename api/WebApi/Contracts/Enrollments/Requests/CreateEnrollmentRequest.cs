namespace WebApi.Contracts.Enrollments.Requests;

public class CreateEnrollmentRequest
{
    public Guid StudentId { get; set; }
    public Guid SubjectId { get; set; }
}
