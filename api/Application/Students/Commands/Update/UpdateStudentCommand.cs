using Application.Students.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Students.Commands.Update;

public record UpdateStudentCommand(Guid Id, UpdateStudentDto Dto): IRequest<Student?>;