using Application.Professors.Commands.Create;
using Application.Professors.Commands.Delete;
using Application.Professors.Commands.Update;
using Application.Professors.DTOs;
using Application.Professors.Queries.GetAll;
using Application.Professors.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Professors.Requests;
using WebApi.Contracts.Professors.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/professor")]
[Authorize]
public class ProfessorController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProfessorResponse>>> Get()
    {
        var professors = await mediator.Send(new GetProfessorsQuery());
        
        return Ok(mapper.Map<List<ProfessorResponse>>(professors));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProfessorResponse?>> Get(Guid id)
    {
        var professor = await mediator.Send(new GetProfessorById(id));
        if (professor == null)
            return NotFound();
        
        return Ok(mapper.Map<ProfessorResponse>(professor));
    }

    [HttpPost]
    public async Task<ActionResult<ProfessorResponse?>> Post([FromBody] CreateProfessorRequest request)
    {
        var dto = mapper.Map<CreateProfessorDto>(request);
        var id = await mediator.Send(new CreateProfessorCommand(dto));
        var professor = await mediator.Send(new GetProfessorById(id));
        
        if (professor == null)
            return NotFound();
        
        return Ok(mapper.Map<ProfessorResponse>(professor));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProfessorResponse?>> Put(Guid id, [FromBody] UpdateProfessorRequest request)
    {
        var dto = mapper.Map<UpdateProfessorDto>(request);
        var professor = await mediator.Send(new UpdateProfessorCommand(id, dto));

        if (professor == null) 
            return NotFound();
        
        return Ok(mapper.Map<ProfessorResponse>(professor));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteProfessorCommand(id));

        if (!result) 
            return NotFound();
        
        return NoContent();
    }
}