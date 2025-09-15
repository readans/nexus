using Application.Subjects.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Subjects.Queries.GetStudents;

public record GetStudentsByIdQuery(Guid Id): IRequest<SubjectStudentsDto?>;