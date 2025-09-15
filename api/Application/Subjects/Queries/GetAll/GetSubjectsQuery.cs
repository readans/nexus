using Domain.Entities;
using MediatR;

namespace Application.Subjects.Queries.GetAll;

public record GetSubjectsQuery(): IRequest<List<Subject>>;