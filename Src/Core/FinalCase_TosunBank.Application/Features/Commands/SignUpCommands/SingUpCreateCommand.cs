using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.SignUpCommands;

public class SingUpCreateCommand : IRequest<bool>
{
    private readonly SignUpCreateDTO model;
    public int Id { get; set; }
    public SingUpCreateCommand(SignUpCreateDTO model)
    {
        this.model = model;
    }
    public class SingUpCreateCommandHandler : IRequestHandler<SingUpCreateCommand, bool>
    {
        private readonly INewCustomerAccountOpeningRequestRepository _preRegistrationRepository;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IMapper _mapper;


        public SingUpCreateCommandHandler(INewCustomerAccountOpeningRequestRepository preRegistrationRepository, UserManager<BasePerson> userManager, IMapper mapper)
        {
            _preRegistrationRepository = preRegistrationRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SingUpCreateCommand request, CancellationToken cancellationToken)
        {
            var userInCustomer = await _userManager.FindByEmailAsync(request.model.Email);
            var userInPreRegister = await _preRegistrationRepository.FindByNationalityNumberAsync(request.model.NationalityNumber);
            if (userInCustomer is not null || userInPreRegister is not null)
                throw new InvalidDataException("Already exists!");
            var newUser = _mapper.Map<NewCustomerAccountOpeningRequest>(request.model);
            await _preRegistrationRepository.CreateAsync(newUser);
            request.Id = newUser.Id;
            return true;
        }
    }
}
