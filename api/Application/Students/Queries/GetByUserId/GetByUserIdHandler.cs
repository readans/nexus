using Application.Students.Specifications;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Queries.GetByUserId;

public class GetByUserIdHandler(IUnitOfWork unitOfWork): IRequestHandler<GetByUserIdQuery, Student?>
{
    public async Task<Student?> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Student>()
            .FirstOrDefaultAsync(new ByUserIdSpecification(request.Uid));
    }
}