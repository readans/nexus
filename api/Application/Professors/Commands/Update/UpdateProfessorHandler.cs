using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Professors.Commands.Update;

public class UpdateProfessorHandler(IUnitOfWork unitOfWork): IRequestHandler<UpdateProfessorCommand, Professor?>
{
    public async Task<Professor?> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = await unitOfWork
            .Repository<Professor>()
            .GetByIdAsync(request.Id);

        if (professor == null) return null;
        professor.Name = request.Dto.Name;
        professor.Email = request.Dto.Email;
        
        unitOfWork
            .Repository<Professor>()
            .Update(professor);

        await unitOfWork.CompleteAsync();
        
        return professor;
    }
}