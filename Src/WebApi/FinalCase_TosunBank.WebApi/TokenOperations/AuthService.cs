using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.WebApi.TokenOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.TokenOperations;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<Person> _userManager;
    private readonly SignInManager<Person> _signingManager;

    public AuthService(IConfiguration configuration, UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Person> signingManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _signingManager = signingManager;
    }

    public async Task<(string Id, string Message)> Login(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if(user is null)
        {
            return (string.Empty, "The username or password is incorrect.");
        }

        //if (!await _userManager.CheckPasswordAsync(user, password))
        var result = await _signingManager.PasswordSignInAsync(user, password, false, false);
        if (!result.Succeeded)
        {
            return (string.Empty, "The username or password is incorrect.");
        }

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


        var token = CreateAccessToken(claims);

        return (user.Id, token);
    }

    public string CreateAccessToken(IEnumerable<Claim> claims)
    {
        var TokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"],
            NotBefore = DateTime.UtcNow,

        };
        var token = TokenHandler.CreateToken(tokenDesc);
        return TokenHandler.WriteToken(token);
    }
}