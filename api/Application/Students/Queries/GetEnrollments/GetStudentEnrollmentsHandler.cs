using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Queries.GetEnrollments;

public class GetStudentEnrollmentsHandler(IUnitOfWork unitOfWork): IRequestHandler<GetStudentEnrollmentsQuery, List<Enrollment>>
{
    public async Task<List<Enrollment>> Handle(GetStudentEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Enrollment>()
            .AsQueryable()
            .Where(x => x.StudentId == request.Id)
            .Include(x => x.Student)
            .ToListAsync(cancellationToken);
    }
}