using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Professors.Commands.Create;

public class CreateProfessorHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<CreateProfessorCommand, Guid>
{
    public async Task<Guid> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = mapper.Map<Professor>(request.Dto);
        
        await unitOfWork
            .Repository<Professor>()
            .AddAsync(professor);

        await unitOfWork.CompleteAsync();
        return professor.Id;
    }
}