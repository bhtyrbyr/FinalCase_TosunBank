using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AccountCommands;

public class NewBankAccountCommand : IRequest<bool>
{
    private readonly NewAccountRequestDTO Model;
    public int NewId { get; set; }

    public NewBankAccountCommand(NewAccountRequestDTO model)
    {
        Model = model;
    }

    public class NewBankAccountCommandHandler : IRequestHandler<NewBankAccountCommand, bool>
    {
        private readonly INewBankAccountOpeningRequestRepository _accountOpeningRequestRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IMapper _mapper;

        public NewBankAccountCommandHandler(INewBankAccountOpeningRequestRepository accountOpeningRequestRepo, UserManager<BasePerson> userManager, IMapper mapper)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(NewBankAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByIdAsync(request.Model.CustomerId);
            if (customer is null)
                throw new ArgumentNullException("No customer record found!");
            var account = _mapper.Map<NewBankAccountOpeningRequest>(request.Model);
            await _accountOpeningRequestRepo.CreateAsync(account);
            request.NewId = account.Id;
            return true;
        }
    }
}
