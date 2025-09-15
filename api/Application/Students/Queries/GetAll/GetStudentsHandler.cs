using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.Students.Queries.GetAll;

public class GetStudentsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStudentsQuery, List<Student>>
{
    public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<Student>()
            .ListAllAsync();
    }
}