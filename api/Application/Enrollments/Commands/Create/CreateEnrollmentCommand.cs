using Application.Enrollments.DTOs;
using MediatR;

namespace Application.Enrollments.Commands.Create;

public record CreateEnrollmentCommand(CreateEnrollmentDto Dto): IRequest<Guid>;