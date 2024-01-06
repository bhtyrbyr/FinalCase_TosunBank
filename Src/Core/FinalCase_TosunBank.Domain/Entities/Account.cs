using FinalCase_TosunBank.Domain.Common;

namespace FinalCase_TosunBank.Domain.Entities;

public class Account : BaseAuditableEntity<int, Authorised>
{
    public Customer Customer { get; set; }
    public double Balance { get; set; }
}
