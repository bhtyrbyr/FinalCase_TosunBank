using FinalCase_TosunBank.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase_TosunBank.Domain.Entities;

public class AccountOpeningRequest : BaseEntity<int>
{
    public string CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public AccountType AccountType { get; set; }
}
