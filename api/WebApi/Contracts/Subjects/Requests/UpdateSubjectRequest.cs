namespace WebApi.Contracts.Subjects.Requests;

public class UpdateSubjectRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public int MaxStudents { get; set; }
}
