namespace FinalCase_TosunBank.Application.DTOs.AccountDTOs;

public class AccountDetailViewDTO
{
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public double TotalBalance { get; set; }
    public string AccountTypeName { get; set; }
    public DateTime CreateDate { get; set; }
    public List<TransactionDetail> TransactionList { get; set; }
}

public class TransactionDetail
{
    public double BeforeBalance { get; set; }
    public double AfterBalance { get; set; }
    public string TransactionTypeName { get; set; }
    public DateTime Date { get; set; }

}
