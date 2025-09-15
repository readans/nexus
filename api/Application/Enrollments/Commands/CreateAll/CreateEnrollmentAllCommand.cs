using Application.Enrollments.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Enrollments.Commands.CreateAll;

public record CreateEnrollmentAllCommand(List<CreateEnrollmentDto> CreateEnrollmentDtos): IRequest;