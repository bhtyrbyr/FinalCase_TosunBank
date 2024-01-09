using FinalCase_TosunBank.Application.DTOs.TransactionDTOs;
using FinalCase_TosunBank.Application.Features.Commands.TramsactionCommands;
using FinalCase_TosunBank.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/tosunbank/v1/[controller]s")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly TosunBankDbContext _dbContext;

    public TransactionController(IMediator mediator, TosunBankDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    [HttpPost("Withdrawal")]
    public async Task<IActionResult> AtmWithrawaval([FromBody] WithdrawalDTO model)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var command = new WithdrawalCommand(model);
        var result = await _mediator.Send(command);
        if (result)
        {
            await transaction.CommitAsync();
            return Ok(result);
        }
        await transaction.RollbackAsync();
        return BadRequest();
    }
}
