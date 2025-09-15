using Application.Subjects.DTOs;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Queries.GetStudents;

public class GetStudentsByIdHandler(IUnitOfWork unitOfWork): IRequestHandler<GetStudentsByIdQuery, SubjectStudentsDto?>
{
    public async Task<SubjectStudentsDto?> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Subject>()
            .AsQueryable()
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Student)
            .Select(s => new SubjectStudentsDto
            {
                SubjectId = s.Id,
                SubjectName = s.Name,
                Students = s.Enrollments.Select(x => new StudentInSubjectDto
                {
                    Name = x.Student!.Name,
                    Email = x.Student.Email
                }).ToList()
            })
            .FirstAsync(x => x.SubjectId == request.Id, cancellationToken);
    }
}