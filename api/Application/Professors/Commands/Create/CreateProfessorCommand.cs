using Application.Professors.DTOs;
using MediatR;

namespace Application.Professors.Commands.Create;

public record CreateProfessorCommand(CreateProfessorDto Dto): IRequest<Guid>;