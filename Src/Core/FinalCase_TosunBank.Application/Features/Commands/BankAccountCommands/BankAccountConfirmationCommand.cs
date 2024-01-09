using AutoMapper;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AccountCommands;

public class BankAccountConfirmationCommand : IRequest<int>
{
    private readonly int Id;
    private readonly string ApprovalId;

    public BankAccountConfirmationCommand(int id, string approvalId)
    {
        Id = id;
        ApprovalId = approvalId;
    }

    public class BankAccountConfirmationCommandHander : IRequestHandler<BankAccountConfirmationCommand, int>
    {
        private readonly INewBankAccountOpeningRequestRepository _accountOpeningRequestRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IMapper _mapper;

        public BankAccountConfirmationCommandHander(INewBankAccountOpeningRequestRepository accountOpeningRequestRepo, IAccountRepository accountRepo, UserManager<BasePerson> userManager, IMapper mapper)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
            _accountRepo = accountRepo;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<int> Handle(BankAccountConfirmationCommand request, CancellationToken cancellationToken)
        {
            var accountOpeningRequest = await _accountOpeningRequestRepo.GetByIdAsync(request.Id);
            if (accountOpeningRequest is null)      throw new ArgumentNullException("No new account request record found!");
            var AccountOppeningApproval = await _userManager.FindByIdAsync(request.ApprovalId) as Authorised;
            if (AccountOppeningApproval is null)    throw new ArgumentException("No authorised record found!");
            var customer = await _userManager.FindByIdAsync(accountOpeningRequest.CustomerId) as Customer;
            if (customer is null)                   throw new ArgumentNullException("No customer record found!");
            try
            {
                var newAccount = _mapper.Map<Account>(accountOpeningRequest);
                newAccount.Customer = customer;
                newAccount.CreatedBy = AccountOppeningApproval;
                await _accountRepo.CreateAsync(newAccount);
                return newAccount.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
