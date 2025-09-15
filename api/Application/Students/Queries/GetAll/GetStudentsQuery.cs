using Domain.Entities;
using MediatR;

namespace Application.Students.Queries.GetAll;

public record GetStudentsQuery: IRequest<List<Student>>;