using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Professors.Commands.Delete;

public class DeleteProfessorHandler(IUnitOfWork unitOfWork): IRequestHandler<DeleteProfessorCommand, bool>
{
    public async Task<bool> Handle(DeleteProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = await unitOfWork
            .Repository<Professor>()
            .GetByIdAsync(request.Id);

        if (professor == null) return false;
        
        unitOfWork
            .Repository<Professor>()
            .Delete(professor);
        
        await unitOfWork.CompleteAsync();
        return true;
    }
}