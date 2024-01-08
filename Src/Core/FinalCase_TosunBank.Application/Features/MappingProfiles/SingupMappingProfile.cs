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
    }
}
