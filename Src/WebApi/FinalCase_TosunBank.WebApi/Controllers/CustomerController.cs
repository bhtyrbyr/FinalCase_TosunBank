using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Application.Features.Commands.CustomerCommands;
using FinalCase_TosunBank.Application.Features.Queries;
using FinalCase_TosunBank.Application.Features.Queries.GetTokenQuery;
using FinalCase_TosunBank.Application.Repository;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/TosunBank/v1/[controller]s")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator, ICustomerRepository repository)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAdminAccesToken", Name = "GetToken")]
    public async Task<IActionResult> GetAdminAccesToken()
    {
        GetTokenQuery query = new GetTokenQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("TestAuth")]
    [Authorize(Roles = "BeybiOYeh")]
    public IActionResult AuthTestFunction()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new GetByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result is null)
            return BadRequest();
        return Ok(result);
    }
    
    [HttpPost("PreRegistration")]
    public async Task<IActionResult> PreRegistration([FromBody] CreateDTO model)
    {
        var validator = new CreateCustommerValidator();
        await validator.ValidateAndThrowAsync(model);
        var command = new CreateCustomer(model);
        var result = await _mediator.Send(command);
        if (result.IsNullOrEmpty())
            return BadRequest();
        return CreatedAtAction(nameof(GetById), new { id = result}, null); 
    }
}
