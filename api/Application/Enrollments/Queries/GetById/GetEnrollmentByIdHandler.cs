using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Enrollments.Queries.GetById;

public class GetEnrollmentByIdHandler(IUnitOfWork unitOfWork): IRequestHandler<GetEnrollmentByIdQuery, Enrollment?>
{
    public async Task<Enrollment?> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Enrollment>()
            .AsQueryable()
            .Include(e => e.Student)
            .Include(e => e.Subject)
            .ThenInclude(s => s.Professor)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}