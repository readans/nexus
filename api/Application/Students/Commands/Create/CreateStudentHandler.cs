using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Commands.Create;

public class CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateStudentCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = mapper.Map<Student>(request.Dto);
        
        await unitOfWork
            .Repository<Student>()
            .AddAsync(student);

        await unitOfWork.CompleteAsync();
        return student.Id;
    }
}