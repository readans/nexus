using Domain.Abstractions;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence.Extensions;

namespace Application.Students.Specifications;

public class ClassmatesBySubjectSpecification(Guid studentId, Guid subjectId)
    : BaseSpecification<Enrollment>(e => e.SubjectId == subjectId && e.StudentId != studentId);
