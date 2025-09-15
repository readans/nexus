using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Subjects.Commands.Create;

public class CreateSubjectHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<CreateSubjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = mapper.Map<Subject>(request.Dto);
        
        await unitOfWork
            .Repository<Subject>()
            .AddAsync(subject);

        await unitOfWork.CompleteAsync();
        return subject.Id;
    }
}