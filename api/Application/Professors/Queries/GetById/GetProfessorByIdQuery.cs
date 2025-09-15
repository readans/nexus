using Domain.Entities;
using MediatR;

namespace Application.Professors.Queries.GetById;

public record GetProfessorById(Guid Id): IRequest<Professor?>;