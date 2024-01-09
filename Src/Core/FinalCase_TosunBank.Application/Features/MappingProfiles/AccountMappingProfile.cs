using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Features.MappingProfiles;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<Account, AccountSimplifiedViewDTO>()
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => Enum.GetName(typeof(AccountTypeEnum), src.AccountType).ToString()));
        CreateMap<NewAccountRequestDTO, NewBankAccountOpeningRequest>()
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => (AccountTypeEnum)src.AccountTypeId));
        CreateMap<NewBankAccountOpeningRequest, Account>()
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => 0.0f))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<Account, AccountDetailViewDTO>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.TotalBalance, opt => opt.MapFrom(src => src.Balance))
            .ForMember(dest => dest.AccountTypeName, opt => opt.MapFrom(src => Enum.GetName(typeof(AccountTypeEnum), src.AccountType).ToString()))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.TransactionList, opt => opt.Ignore());
        CreateMap<AccountStatement, TransactionDetail>()
            .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => Enum.GetName(typeof(TransactionTypeEnum), src.TransactionTypeId)))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.BeforeBalance, opt => opt.MapFrom(src => src.BalanceBeforeTransaction))
            .ForMember(dest => dest.AfterBalance, opt => opt.MapFrom(src => src.BalanceAfterTransaction));
    }
}
