namespace FinalCase_TosunBank.Application.DTOs.CustomerDTOs;

public class CreateDTO
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string  Address { get; set; }
    public string NationalityNumber { get; set; }
    public DateTime BirthDay { get; set; }

}
