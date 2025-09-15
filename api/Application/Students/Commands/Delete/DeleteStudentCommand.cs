using Domain.Entities;
using MediatR;

namespace Application.Students.Commands.Delete;

public record DeleteStudentCommand(Guid Id): IRequest<bool>;
