using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Application.Features.Commands.SignUpCommands;
using FinalCase_TosunBank.Application.Features.Queries.SingUpQueries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/tosunbank/v1/[controller]s")]
[ApiController]
public class SignUpController : ControllerBase
{
    private readonly IMediator _mediator;

    public SignUpController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllSignUpRegister")]
    [Authorize(Roles = "CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();
        var result = await _mediator.Send(query);
        if (!result.Any()) return NotFound("No record found!");
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetSignUpRegisterDetail")]
    [Authorize(Roles = "CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result is null) return NotFound("No record found!");
        return Ok(result);
    }

    [HttpPost(Name = "SignUp")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCreateDTO model)
    {
        var commandValidator = new SingUpCreateCommandValidator();
        await commandValidator.ValidateAndThrowAsync(model);
        var command = new SingUpCreateCommand(model);
        var result = await _mediator.Send(command);
        if (result)
            return CreatedAtAction(nameof(GetById), new { id = command.Id }, null);
        return BadRequest("Failed to create a record!");
    }

    [HttpPut("{id}", Name = "ConfigPreRegistration")]
    [Authorize(Roles = "CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> ConfirmPreRegistration(int id, [FromQuery] string ApprovalId)
    {
        var command = new SingUpConfirmationCommand(id, ApprovalId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
