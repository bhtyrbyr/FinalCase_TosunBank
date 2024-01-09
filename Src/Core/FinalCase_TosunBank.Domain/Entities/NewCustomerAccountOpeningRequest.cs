namespace FinalCase_TosunBank.Domain.Entities;

public class NewCustomerAccountOpeningRequest
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalityNumber { get; set; }
    public DateTime BirthDay { get; set; }
}
