using FinalCase_TosunBank.Application.DTOs.TransactionDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.TramsactionCommands;

public class TransferMoneyCommand : IRequest<bool>
{
    private readonly TransferMoneyDTO Model;

    public TransferMoneyCommand(TransferMoneyDTO model)
    {
        Model = model;
    }

    public class TransferMoneyCommandHandler : IRequestHandler<TransferMoneyCommand, bool>
    {
        private readonly IAccountStatementRepository _accountStatementRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IAccountRepository _accountRepo;

        public TransferMoneyCommandHandler(IAccountStatementRepository accountStatementRepo, UserManager<BasePerson> userManager, IAccountRepository accountRepo)
        {
            _accountStatementRepo = accountStatementRepo;
            _userManager = userManager;
            _accountRepo = accountRepo;
        }

        public async Task<bool> Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByIdAsync(request.Model.CustomerId);
            if (customer is null) throw new ArgumentNullException("No customer record found!");
            var account = await _accountRepo.GetByIdAsync(request.Model.AccountId);
            var targetAccount = await _accountRepo.GetByIdAsync(request.Model.TargetAccountId);
            if ((account is null && targetAccount is null) && account.CustomerId != customer.Id) throw new ArgumentNullException("No account record found!");
            if (request.Model.Balance > account.Balance) throw new InvalidOperationException("Insufficient account balance!");
            var accountBalanceBefore = account.Balance;
            var targetAccountBalanceBefore = targetAccount.Balance;
            account.Balance -= request.Model.Balance;
            targetAccount.Balance += request.Model.Balance;
            await _accountRepo.UpdateAsync(account);
            await _accountRepo.UpdateAsync(targetAccount);
            var accountTransactionRecord = new AccountStatement(){
                CreatedBy = account,
                BalanceBeforeTransaction = accountBalanceBefore,
                BalanceAfterTransaction = account.Balance,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 4
            };
            var targetAccountTransactionRecord = new AccountStatement(){
                CreatedBy = targetAccount,
                BalanceBeforeTransaction = targetAccountBalanceBefore,
                BalanceAfterTransaction = targetAccount.Balance,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 3
            };
            await _accountStatementRepo.CreateAsync(accountTransactionRecord);
            await _accountStatementRepo.CreateAsync(targetAccountTransactionRecord);
            return true;
        }
    }
}
