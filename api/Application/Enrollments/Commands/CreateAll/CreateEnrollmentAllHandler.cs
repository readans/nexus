using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Enrollments.Commands.CreateAll;

public class CreateEnrollmentAllHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<CreateEnrollmentAllCommand>
{
    public async Task Handle(CreateEnrollmentAllCommand request, CancellationToken cancellationToken)
    {
        var enrollments = mapper.Map<List<Enrollment>>(request.CreateEnrollmentDtos);

        await unitOfWork
            .Repository<Enrollment>()
            .AddRangeAsync(enrollments);
        
        await unitOfWork.CompleteAsync();
    }
}