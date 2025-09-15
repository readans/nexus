using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Queries.GetById;

public class GetSubjectHandler(IUnitOfWork unitOfWork): IRequestHandler<GetSubjectByIdQuery, Subject?>
{
    public async Task<Subject?> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Subject>()
            .AsQueryable()
            .Include(s => s.Professor)
            .FirstAsync(s => s.Id == request.Id, cancellationToken);
    }
}