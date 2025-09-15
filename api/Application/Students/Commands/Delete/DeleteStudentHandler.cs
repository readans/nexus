using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Commands.Delete;

public class DeleteStudentHandler(IUnitOfWork unitOfWork): IRequestHandler<DeleteStudentCommand, bool>
{
    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await unitOfWork
            .Repository<Student>()
            .GetByIdAsync(request.Id);

        if (student == null) return false;
        
        unitOfWork
            .Repository<Student>()
            .Delete(student);
        
        await unitOfWork.CompleteAsync();
        return true;
    }
}