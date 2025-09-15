using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Professors.Queries.GetById;

public class GetProfessorByIdHandler(IUnitOfWork unitOfWork): IRequestHandler<GetProfessorById, Professor?>
{
    public async Task<Professor?> Handle(GetProfessorById request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Professor>()
            .GetByIdAsync(request.Id);
    }
}