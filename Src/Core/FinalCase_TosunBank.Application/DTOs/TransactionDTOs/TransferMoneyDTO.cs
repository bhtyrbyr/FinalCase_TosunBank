namespace FinalCase_TosunBank.Application.DTOs.TransactionDTOs;

public class TransferMoneyDTO
{
    public string CustomerId { get; set; }
    public int AccountId { get; set; }
    public int TargetAccountId { get; set; }
    public float Balance { get; set; }
}
