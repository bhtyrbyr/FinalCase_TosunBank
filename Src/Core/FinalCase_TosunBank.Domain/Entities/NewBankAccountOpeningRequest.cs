using FinalCase_TosunBank.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase_TosunBank.Domain.Entities;

public class NewBankAccountOpeningRequest : BaseEntity<int>
{
    public string CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public AccountTypeEnum AccountType { get; set; }
}
