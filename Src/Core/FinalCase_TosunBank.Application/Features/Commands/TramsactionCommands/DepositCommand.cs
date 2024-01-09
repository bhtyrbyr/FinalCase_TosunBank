using FinalCase_TosunBank.Application.DTOs.TransactionDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.TramsactionCommands;

public class DepositCommand : IRequest<bool>
{
    private readonly DepositMoneyDTO Model;

    public DepositCommand(DepositMoneyDTO model)
    {
        Model = model;
    }

    public class DepositCommandHandler : IRequestHandler<DepositCommand, bool>
    {
        private readonly IAccountStatementRepository _accountStatementRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IAccountRepository _accountRepo;

        public DepositCommandHandler(IAccountStatementRepository accountStatementRepo, UserManager<BasePerson> userManager, IAccountRepository accountRepo)
        {
            _accountStatementRepo = accountStatementRepo;
            _userManager = userManager;
            _accountRepo = accountRepo;
        }
        public async Task<bool> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByIdAsync(request.Model.CustomerId);
            if (customer is null)
                throw new ArgumentNullException("No customer record found!");
            var account = await _accountRepo.GetByIdAsync(request.Model.AccountId);
            if (account is null && account.CustomerId != customer.Id)
                throw new ArgumentNullException("No account record found!");
            var beforeTransactionBalance = account.Balance;
            account.Balance += request.Model.AmountToBeWithDrawn;
            await _accountRepo.UpdateAsync(account);
            var transactionRecord = new AccountStatement()
            {
                CreatedBy = account,
                BalanceBeforeTransaction = beforeTransactionBalance,
                BalanceAfterTransaction = account.Balance,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 1
            };
            await _accountStatementRepo.CreateAsync(transactionRecord);
            try
            {
                int cardid = Convert.ToInt32(request.Model.CardNo);
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
