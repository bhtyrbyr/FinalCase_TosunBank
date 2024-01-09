using FinalCase_TosunBank.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase_TosunBank.Domain.Entities;

public class Account : BaseAuditableEntity<int, Authorised>
{
    public string CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public double Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
}
