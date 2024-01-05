using System.Security.Claims;

namespace FinalCase_TosunBank.WebApi.TokenOperations;

public interface IAuthService
{
    Task<(string Id, string Message)> Login(string userName, string password);
    string CreateAccessToken(IEnumerable<Claim> claims);
}
