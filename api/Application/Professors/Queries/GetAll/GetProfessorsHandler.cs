using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Professors.Queries.GetAll;

public class GetProfessorsHandler(IUnitOfWork unitOfWork): IRequestHandler<GetProfessorsQuery, List<Professor>>
{
    public async Task<List<Professor>> Handle(GetProfessorsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Professor>()
            .ListAllAsync();
    }
}