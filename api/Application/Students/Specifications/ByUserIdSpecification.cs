using Domain.Entities;
using Infrastructure.Persistence.Extensions;

namespace Application.Students.Specifications;

public class ByUserIdSpecification(string uid) :
    BaseSpecification<Student>(s => s.UID == uid);