using Domain.Entities;
using MediatR;

namespace Application.Enrollments.Queries.GetById;

public record GetEnrollmentByIdQuery(Guid Id): IRequest<Enrollment?>;