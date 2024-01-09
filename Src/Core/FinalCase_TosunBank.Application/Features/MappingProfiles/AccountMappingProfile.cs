using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Features.MappingProfiles;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<Account, AccountSimplifiedViewDTO>()
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => Enum.GetName(typeof(AccountType), src.AccountType).ToString()));
        CreateMap<NewAccountRequestDTO, NewBankAccountOpeningRequest>()
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => (AccountType)src.AccountTypeId));
        CreateMap<NewBankAccountOpeningRequest, Account>()
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => 0.0f))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
