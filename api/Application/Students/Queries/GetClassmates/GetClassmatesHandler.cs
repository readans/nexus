using Application.Students.Specifications;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Queries.GetClassmates;

public class GetClassmatesHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<GetClassmatesQuery, List<Student>>
{
    public async Task<List<Student>> Handle(GetClassmatesQuery request, CancellationToken cancellationToken)
    {
        var enrollments = await unitOfWork
            .Repository<Enrollment>()
            .AsQueryable()
            .Include(x => x.Student)
            .Where(x => x.StudentId != request.Id && x.SubjectId == request.SubjectId)
            .Select(x => x.Student)
            .ToListAsync(cancellationToken);
            //.ListAsync(new ClassmatesBySubjectSpecification(request.Id, request.SubjectId));
        
        return mapper.Map<List<Student>>(enrollments);
    }
}