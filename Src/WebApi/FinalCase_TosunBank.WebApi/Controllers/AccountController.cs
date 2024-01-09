using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Application.Features.Commands.AccountCommands;
using FinalCase_TosunBank.Application.Features.Queries.AccountQueries;
using FinalCase_TosunBank.Application.Features.Queries.BankAccountQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/tosunbank/v1/[controller]s")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAccounts/{id}", Name = "CustomerAccounts")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetAccounts(string id)
    {
        var command = new AllBankAccountsOfTheCustomerQuery(id);
        var result = await _mediator.Send(command);
        if(result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("GetAccountDetail/{id}", Name = "CustomerAccountDetail")]
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetAccountDetail(int id)
    {
        var command = new BankAccountDetailGetByIdQuery(id);
        var result = await _mediator.Send(command);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPut("ConfirmNewAccount/{id}", Name = "ConfirmNewAccountOpeningRequest")]
    [Authorize(Roles = "CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> ConfirmNewAccountOpeningRequest(int id, [FromQuery] string ApprovalId)
    {
        var command = new BankAccountConfirmationCommand(id, ApprovalId);
        var result = await _mediator.Send(command);
        if (result == 0)
            return BadRequest();
        return Ok(result);
    }

    [HttpGet("NewAccount/", Name = "GetAccountOpeningRequestAll")]
    [Authorize(Roles = "CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> GetAccountOpeningRequestAll()
    {
        var command = new GetNewBankAccountOpeningRequestGetAllQuery();
        var result = await _mediator.Send(command);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("NewAccount/{id}", Name = "GetAccountOpeningRequestById")]
    [Authorize(Roles = "Customer,CustomerActionsPersonnel,Director,Admin")]
    public async Task<IActionResult> GetAccountOpeningRequestById(int id)
    {
        var command = new GetNewBankAccountOpeningRequestGetByIdQuery(id);
        var result = await _mediator.Send(command);
        if(result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("NewAccount", Name = "AccountOpeningRequest")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> NewAccountRequest([FromBody] NewAccountRequestDTO model)
    {
        var command = new NewBankAccountCommand(model);
        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest();
        return CreatedAtAction(nameof(GetAccountOpeningRequestById), new {id = command.NewId}, null);
    }
}
