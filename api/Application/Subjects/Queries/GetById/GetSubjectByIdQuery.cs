using Domain.Entities;
using MediatR;

namespace Application.Subjects.Queries.GetById;

public record GetSubjectByIdQuery(Guid Id): IRequest<Subject?>;