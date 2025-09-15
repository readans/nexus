using Application.Subjects.Commands.Create;
using Application.Subjects.Queries.GetAll;
using Application.Subjects.Queries.GetById;
using Application.Subjects.Queries.GetStudents;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Subjects.Requests;
using WebApi.Contracts.Subjects.Responses;

namespace WebApi.Controllers;

[Route("api/subject")]
[ApiController]
public class SubjectController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SubjectResponse>>> Get()
    {
        var subjects = await mediator.Send(new GetSubjectsQuery());
        
        return Ok(mapper.Map<List<SubjectResponse>>(subjects));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SubjectResponse?>> Get(Guid id)
    {
        var subject = await mediator.Send(new GetSubjectByIdQuery(id));
        if (subject == null)
            return NotFound();
        
        return Ok(mapper.Map<SubjectResponse>(subject));
    }
    
    [HttpGet("{id:guid}/students")]
    public async Task<ActionResult<SubjectStudentsResponse?>> GetStudents(Guid id)
    { 
        var subjectStudentsDto = await mediator.Send(new GetStudentsByIdQuery(id));
        
        return Ok(mapper.Map<SubjectStudentsResponse>(subjectStudentsDto));
    }

    [HttpPost]
    public async Task<ActionResult<SubjectResponse?>> Post([FromBody] CreateSubjectRequest request)
    {
        var dto = mapper.Map<CreateSubjectDto>(request);
        var id = await mediator.Send(new CreateSubjectCommand(dto));
        var subject = await mediator.Send(new GetSubjectByIdQuery(id));
        
        if (subject == null)
            return NotFound();
        
        return CreatedAtAction("Post", mapper.Map<SubjectResponse>(subject));
    }

}