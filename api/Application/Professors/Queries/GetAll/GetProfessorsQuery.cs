using Domain.Entities;
using MediatR;

namespace Application.Professors.Queries.GetAll;

public record GetProfessorsQuery(): IRequest<List<Professor>>;