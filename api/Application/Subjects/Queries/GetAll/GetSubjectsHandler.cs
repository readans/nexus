using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Queries.GetAll;

public class GetSubjectsHandler(IUnitOfWork unitOfWork): IRequestHandler<GetSubjectsQuery, List<Subject>>
{
    public async Task<List<Subject>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Subject>()
            .AsQueryable()
            .Include(s => s.Professor)
            .ToListAsync(cancellationToken);
    }
}