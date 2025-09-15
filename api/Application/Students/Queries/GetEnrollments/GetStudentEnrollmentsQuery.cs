using Domain.Entities;
using MediatR;

namespace Application.Students.Queries.GetEnrollments;

public record GetStudentEnrollmentsQuery(Guid Id): IRequest<List<Enrollment>>;