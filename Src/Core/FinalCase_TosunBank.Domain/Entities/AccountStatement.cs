using FinalCase_TosunBank.Domain.Common;

namespace FinalCase_TosunBank.Domain.Entities;

public class AccountStatement : BaseAuditableEntity<int, Account>
{
    public byte TransactionTypeId { get; set; }
    public int CreatedById { get; set; }
    public TransactionType TransactionType { get; set; }
    public double BalanceBeforeTransaction { get; set; }
    public double BalanceAfterTransaction { get; set; }
}
