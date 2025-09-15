using MediatR;

namespace Application.Professors.Commands.Delete;

public record DeleteProfessorCommand(Guid Id): IRequest<bool>;