using Domain.Entities;
using Infrastructure.Persistence.Extensions;

namespace Application.Students.Specifications;

public class StudentsBySubjectIdSpecification : BaseSpecification<Subject>
{
    public StudentsBySubjectIdSpecification(Guid id)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.Enrollments);
    }
}