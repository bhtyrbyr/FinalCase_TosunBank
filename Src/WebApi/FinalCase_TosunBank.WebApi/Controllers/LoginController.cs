using FinalCase_TosunBank.Application.DTOs.LoginDTO;
using FinalCase_TosunBank.Application.Features.Commands.LoginCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/tosunbank/v1/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] BasePersonLoginDTO model)
    {
        var command = new GetTokenQuery(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
