using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Queries.GetById;

public class GetStudentByIdHandler(IUnitOfWork unitOfWork): IRequestHandler<GetStudentByIdQuery, Student?>
{
    public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Student>()
            .GetByIdAsync(request.Id);
    }
}