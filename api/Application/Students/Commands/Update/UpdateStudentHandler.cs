using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Commands.Update;

public class UpdateStudentHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateStudentCommand, Student?>
{
    public async Task<Student?> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await unitOfWork
            .Repository<Student>()
            .GetByIdAsync(request.Id);

        if (student == null) return null;
        student.Name = request.Dto.Name;
        student.Email = request.Dto.Email;
        student.PhotoUrl = request.Dto.PhotoUrl;
        student.TotalCredits = request.Dto.TotalCredits;
        student.UID = request.Dto.UID;
        
        unitOfWork
            .Repository<Student>()
            .Update(student);

        await unitOfWork.CompleteAsync();
        
        return student;
    }
}