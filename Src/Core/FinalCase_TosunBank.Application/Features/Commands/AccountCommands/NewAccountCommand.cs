using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AccountCommands;

public class NewAccountCommand : IRequest<bool>
{
    private readonly NewAccountRequestDTO Model;
    public int NewId { get; set; }

    public NewAccountCommand(NewAccountRequestDTO model)
    {
        Model = model;
    }

    public class NewAccountCommandHandler : IRequestHandler<NewAccountCommand, bool>
    {
        private readonly IAccountOpeningRequestRepository _accountOpeningRequestRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IMapper _mapper;

        public NewAccountCommandHandler(IAccountOpeningRequestRepository accountOpeningRequestRepo, UserManager<BasePerson> userManager, IMapper mapper)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(NewAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByIdAsync(request.Model.CustomerId);
            if (customer is null)
                throw new ArgumentNullException("No customer record found!");
            var account = _mapper.Map<AccountOpeningRequest>(request.Model);
            await _accountOpeningRequestRepo.CreateAsync(account);
            request.NewId = account.Id;
            return true;
        }
    }
}
