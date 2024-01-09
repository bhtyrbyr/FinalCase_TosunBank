using FinalCase_TosunBank.Application.DTOs.AuthoriseDTO;
using FinalCase_TosunBank.Application.Features.Commands.AuthorisationCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/tosunbank/v1/[controller]s")]
[ApiController]
public class AuthorisationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorisationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateAuthorisation/")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAuthorisation([FromQuery] string roleName)
    {
        var command = new CreateCommand(roleName);
        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Failed to create a new record!");
        return Ok(result);

    }


    [HttpGet("AuthoriseUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AuthoriseUser([FromBody] AuthorisationArrangementDTO model)
    {
        var command = new AuthorisedCommand(model);
        var result = await _mediator.Send(command);
        if (!result)
            NotFound();
        return NoContent();
    }

    [HttpGet("UnauthoriseUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UnauthoriseUser([FromBody] AuthorisationArrangementDTO model)
    {
        var command = new UnauthorisedCommand(model);
        var result = await _mediator.Send(command);
        if (!result)
            NotFound();
        return NoContent();
    }
}
