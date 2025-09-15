using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Enrollments.Commands.Create;

public class CreateEnrollmentHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<CreateEnrollmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = mapper.Map<Enrollment>(request.Dto);
        
        await unitOfWork
            .Repository<Enrollment>()
            .AddAsync(enrollment);

        await unitOfWork.CompleteAsync();
        return enrollment.Id;
    }
}