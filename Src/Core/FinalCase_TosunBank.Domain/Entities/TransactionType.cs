using FinalCase_TosunBank.Domain.Common;

namespace FinalCase_TosunBank.Domain.Entities;

public class TransactionType : BaseEntity<byte>
{
    public string Name { get; set; }
}
