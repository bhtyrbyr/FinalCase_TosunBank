using FinalCase_TosunBank.Application.DTOs;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Persistence.Context;
using FinalCase_TosunBank.WebApi.TokenOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.TokenOperations;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/v1/[controller]s")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly TosunBankDbContext _dbContext;
    private readonly UserManager<Person> _userManager;
    public PersonController(IAuthService authService, TosunBankDbContext dbContext, UserManager<Person> userManager)
    {
        _authService = authService;
        _dbContext = dbContext;
        _userManager = userManager;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginPerson([FromBody] LoginDTO model)
    {
        var result = await _authService.Login(model.UserName, model.Password);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> CreateNewRegister([FromBody] PersonRegisterDTO model)
    {
        Person newPerson = new Person
        {
            Id = "100",
            UserName = model.email,
            FirstName = model.FirstName,
            LastName = model.LastName,
        };
        var result = await _userManager.CreateAsync(newPerson, model.Password);
        return Ok(result);
    }
}
