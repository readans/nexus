using Application.Students.DTOs;
using MediatR;

namespace Application.Students.Commands.Create;

public record class CreateStudentCommand(CreateStudentDto Dto): IRequest<Guid>;