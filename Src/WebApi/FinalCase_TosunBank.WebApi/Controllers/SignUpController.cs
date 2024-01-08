using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
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
    [Authorize(Roles = "CustomerActionsPersonnel")]
    [Authorize(Roles = "Director")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpGet("/{id}", Name = "GetSignUpRegisterDetail")]
    [Authorize(Roles = "CustomerActionsPersonnel")]
    [Authorize(Roles = "Director")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok();
    }

    [HttpPost(Name = "SignUp")]
    public async Task<IActionResult> SignUp([FromBody] CreateDTO model)
    {
        return Ok();
    }

    [HttpPut("{id}", Name = "ConfigPreRegistration")]
    [Authorize(Roles = "CustomerActionsPersonnel")]
    [Authorize(Roles = "Director")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ConfirmPreRegistration(int id)
    {
        return Ok();
    }
}
