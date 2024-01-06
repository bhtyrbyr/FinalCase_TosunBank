using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Features.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateDTO, Customer>();
    }
}
