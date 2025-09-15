using MediatR;

namespace Application.Subjects.Commands.Create;

public record CreateSubjectCommand(CreateSubjectDto Dto): IRequest<Guid>;