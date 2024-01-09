using FinalCase_TosunBank.Application.DTOs.TransactionDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.TramsactionCommands;

public class WithdrawalCommand : IRequest<bool>
{
    private readonly WithdrawalDTO Model;

    public WithdrawalCommand(WithdrawalDTO model)
    {
        Model = model;
    }

    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCommand, bool>
    {
        private readonly IAccountStatementRepository _accountStatementRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IAccountRepository _accountRepo;

        public WithdrawalCommandHandler(IAccountStatementRepository accountStatementRepo, UserManager<BasePerson> userManager, IAccountRepository accountRepo)
        {
            _accountStatementRepo = accountStatementRepo;
            _userManager = userManager;
            _accountRepo = accountRepo;
        }

        public async Task<bool> Handle(WithdrawalCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByIdAsync(request.Model.CustomerId);
            if (customer is null)
                throw new ArgumentNullException("No customer record found!");
            var account = await _accountRepo.GetByIdAsync(request.Model.AccountId);
            if (account is null && account.CustomerId != customer.Id) 
                throw new ArgumentNullException("No account record found!");
            if (request.Model.AmountToBeWithDrawn > account.Balance)
                throw new InvalidOperationException("Insufficient account balance!");
            account.Balance -= request.Model.AmountToBeWithDrawn;
            await _accountRepo.UpdateAsync(account);
            var transactionRecord = new AccountStatement()
            {
                CreatedBy = account,
                BalanceBeforeTransaction = account.Balance + request.Model.AmountToBeWithDrawn,
                BalanceAfterTransaction = account.Balance,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 2
            };
            await _accountStatementRepo.CreateAsync(transactionRecord);
            return true;

        }
    }
}
