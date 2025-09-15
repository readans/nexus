using Application.Enrollments.Commands.Create;
using Application.Enrollments.Commands.CreateAll;
using Application.Enrollments.DTOs;
using Application.Enrollments.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Enrollments.Requests;
using WebApi.Contracts.Enrollments.Responses;

namespace WebApi.Controllers;

[Route("api/enrollment")]
[ApiController]
public class EnrollmentController(IMediator mediator, IMapper mapper): ControllerBase
{
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EnrollmentResponse?>> Get(Guid id)
    {
        var enrollment = await mediator.Send(new GetEnrollmentByIdQuery(id));
        if (enrollment == null)
            return NotFound();
        
        return Ok(mapper.Map<EnrollmentResponse>(enrollment));
    }
    
    [HttpPost]
    public async Task<ActionResult<EnrollmentResponse?>> Post([FromBody] CreateEnrollmentRequest request)
    {
        var dto = mapper.Map<CreateEnrollmentDto>(request);
        var id = await mediator.Send(new CreateEnrollmentCommand(dto));
        var enrollment = await mediator.Send(new GetEnrollmentByIdQuery(id));
        
        if (enrollment == null)
            return NotFound();
        
        return Ok(mapper.Map<EnrollmentResponse>(enrollment));
    }
    
    [HttpPost("enrollmentAll")]
    public async Task<ActionResult> PostAll([FromBody] List<CreateEnrollmentRequest> request)
    {
        var dtos = mapper.Map<List<CreateEnrollmentDto>>(request);
        await mediator.Send(new CreateEnrollmentAllCommand(dtos));

        return Ok();
    }
}