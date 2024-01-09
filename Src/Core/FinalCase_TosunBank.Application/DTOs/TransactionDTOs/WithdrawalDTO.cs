namespace FinalCase_TosunBank.Application.DTOs.TransactionDTOs;

public class WithdrawalDTO
{
    public string AtmId { get; set; }
    public string CustomerId { get; set; }
    public int AccountId { get; set; }
    public string CardNo { get; set; }
    public float AmountToBeWithDrawn { get; set; }
}
