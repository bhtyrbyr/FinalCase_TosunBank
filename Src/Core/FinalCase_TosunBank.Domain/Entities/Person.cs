using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Domain.Entities;

public class Person : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
