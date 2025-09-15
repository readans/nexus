using Application.Professors.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Professors.Commands.Update;

public record UpdateProfessorCommand(Guid Id, UpdateProfessorDto Dto): IRequest<Professor?>;