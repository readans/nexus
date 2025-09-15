using Domain.Entities;
using MediatR;

namespace Application.Students.Queries.GetClassmates;

public record GetClassmatesQuery(Guid Id, Guid SubjectId): IRequest<List<Student>>;