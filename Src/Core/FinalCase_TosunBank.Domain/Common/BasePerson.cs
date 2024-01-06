using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Domain.Common;

public class BasePerson : IdentityUser
{
    public string NationalityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecurityCode { get; set; }
    public string Address { get; set; }
    public DateTime BirthDay { get; set; }
}
