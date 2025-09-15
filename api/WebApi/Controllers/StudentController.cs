using Application.Students.Commands.Create;
using Application.Students.Commands.Delete;
using Application.Students.Commands.Update;
using Application.Students.DTOs;
using Application.Students.Queries.GetAll;
using Application.Students.Queries.GetById;
using Application.Students.Queries.GetClassmates;
using Application.Students.Queries.GetEnrollments;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Students.Requests;
using WebApi.Contracts.Students.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/student")]
[Authorize]
public class StudentController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<StudentResponse>>> Get()
    {
        var students = await mediator.Send(new GetStudentsQuery());
        
        return Ok(mapper.Map<List<StudentResponse>>(students));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentResponse?>> Get(Guid id)
    {
        var student = await mediator.Send(new GetStudentByIdQuery(id));
        if (student == null)
            return NotFound();
        
        return Ok(mapper.Map<StudentResponse>(student));
    }
    
    [HttpGet("{id:guid}/enrollments")]
    public async Task<ActionResult<List<StudentEnrollmentResponse>>> GetEnrollments(Guid id)
    {
        var enrollments = await mediator.Send(new GetStudentEnrollmentsQuery(id));
        return Ok(mapper.Map<List<StudentEnrollmentResponse>>(enrollments));
    }

    [HttpGet("{id:guid}/classmates/{subjectId:guid}")]
    public async Task<ActionResult<List<ClassmateResponse>>> GetClassmates(Guid id, Guid subjectId)
    {
        var classmates = await mediator.Send(new GetClassmatesQuery(id, subjectId));
        return Ok(mapper.Map<List<ClassmateResponse>>(classmates));
    }

    [HttpPost]
    public async Task<ActionResult<StudentResponse?>> Post([FromBody] CreateStudentRequest request)
    {
        var dto = mapper.Map<CreateStudentDto>(request);
        var id = await mediator.Send(new CreateStudentCommand(dto));
        var student = await mediator.Send(new GetStudentByIdQuery(id));
        
        if (student == null)
            return NotFound();
        
        return Ok(mapper.Map<StudentResponse>(student));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<StudentResponse?>> Put(Guid id, [FromBody] UpdateStudentRequest request)
    {
        var dto = mapper.Map<UpdateStudentDto>(request);
        var student = await mediator.Send(new UpdateStudentCommand(id, dto));

        if (student == null)
            return NotFound();
        
        return Ok(mapper.Map<StudentResponse>(student));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteStudentCommand(id));
        if (!result) 
            return NotFound();
        
        return NoContent();
    }
}