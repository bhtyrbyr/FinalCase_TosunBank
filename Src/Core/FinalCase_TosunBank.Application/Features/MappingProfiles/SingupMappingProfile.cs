using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Application.DTOs.SingupDTOs;
using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Features.MappingProfiles;

public class SingupMappingProfile : Profile
{
    public SingupMappingProfile()
    {
        CreateMap<PreRegistration, SignUpViewDTO>();
        CreateMap<SignUpCreateDTO, PreRegistration>();
        CreateMap<PreRegistration, Customer>()
            .ForMember(desc => desc.Id, opt => opt.Ignore())
            .ForMember(desc => desc.SecurityCode, opt => opt.MapFrom(src => src.FirstName.Substring(0,2) + src.LastName.Substring(0, 2) + "@" + src.PhoneNumber.Substring(0, 4)))
            .ForMember(desc => desc.CreditScore, opt => opt.MapFrom(src => 100))
            .ForMember(desc => desc.AccountCreateDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(desc => desc.AccountOppeningApprovalId, opt => opt.Ignore())
            .ForMember(desc => desc.AccountOppeningApproval, opt => opt.Ignore())
            .ForMember(desc => desc.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(desc => desc.PasswordHash, opt => opt.Ignore())
            .ForMember(desc => desc.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
}
