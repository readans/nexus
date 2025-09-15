using Application.Students.Commands.Create;
using Application.Students.DTOs;
using Application.Students.Queries.GetById;
using Application.Students.Queries.GetByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Auth.Requests;
using WebApi.Contracts.Students.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/auth")]
[Authorize]
public class AuthController(IMediator mediator, IMapper mapper): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<StudentResponse?>> Post([FromBody] LoginRequest request)
    {
        var student = await mediator.Send(new GetByUserIdQuery(request.UID));

        if (student != null)
            return Ok(mapper.Map<StudentResponse>(student));

        var dto = mapper.Map<CreateStudentDto>(request);
        var id = await mediator.Send(new CreateStudentCommand(dto));
        student = await mediator.Send(new GetStudentByIdQuery(id));
        
        if (student == null)
            return NotFound();
        
        return Ok(mapper.Map<StudentResponse>(student));
    }
}