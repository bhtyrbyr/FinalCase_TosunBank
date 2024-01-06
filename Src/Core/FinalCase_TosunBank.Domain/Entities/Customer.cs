using FinalCase_TosunBank.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase_TosunBank.Domain.Entities;

public class Customer : BasePerson
{
    public double Salary { get; set; }
    public bool SalaryCustomer { get; set; }
    public float CreditScore { get; set; }
    public DateTime AccountCreateDate { get; set; }
    public string? AccountOppeningApprovalId { get; set; }

    [ForeignKey("AccountOppeningApprovalId")]
    public Authorised AccountOppeningApproval { get; set; }
    public List<Account> Accounts { get; set; }
}
