using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.DTOs.AccountDTOs;

public class AccountSimplifiedViewDTO
{
    public string AccountType { get; set; }
    public double Balance { get; set; }
}
