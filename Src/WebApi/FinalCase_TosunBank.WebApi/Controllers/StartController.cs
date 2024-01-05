using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/v1/[controller]s")]
[ApiController]
public class StartController : ControllerBase
{
    private readonly string username = "bhtyrbyr";
    private readonly IConfiguration configuration;

    public StartController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpGet("")]
    [Authorize(Roles = "BurayaGelebilir")]
    public async Task<IActionResult> GetAllAuth()
    {
        return Ok("Selam Dünyalı");
    }

    [HttpGet("Role1")]
    public async Task<IActionResult> GetAllOpen1()
    {
        string msg = DateTime.UtcNow.ToString();
        var TokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, "BurayaGelebilir")
            }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Issuer = configuration["JWT:Issuer"],
            Audience = configuration["JWT:Audience"],
            NotBefore = DateTime.UtcNow,
            
        };
        var Token = TokenHandler.CreateToken(tokenDesc);
        return Ok(string.Format($"Zaman : {msg}, Token : {TokenHandler.WriteToken(Token)}"));
    }

    [HttpGet("Role2")]
    public async Task<IActionResult> GetAllOpen2()
    {
        string msg = DateTime.UtcNow.ToString();
        var TokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "BurayaGelemez")
            }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Issuer = configuration["JWT:Issuer"],
            Audience = configuration["JWT:Audience"],
            NotBefore = DateTime.UtcNow
        };
        var Token = TokenHandler.CreateToken(tokenDesc);
        return Ok(string.Format($"Zaman : {msg}, Token : {TokenHandler.WriteToken(Token)}"));
    }
}
