using Domain.Entities;
using MediatR;

namespace Application.Students.Queries.GetByUserId;

public record GetByUserIdQuery(string Uid): IRequest<Student?>;