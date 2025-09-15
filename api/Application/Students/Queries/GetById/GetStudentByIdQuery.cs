using Domain.Entities;
using MediatR;

namespace Application.Students.Queries.GetById;

public record GetStudentByIdQuery(Guid Id): IRequest<Student?>;