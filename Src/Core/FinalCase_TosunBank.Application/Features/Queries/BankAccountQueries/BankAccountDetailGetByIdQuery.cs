using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Queries.BankAccountQueries;

public class BankAccountDetailGetByIdQuery : IRequest<AccountDetailViewDTO>
{
    private readonly int Id;

    public BankAccountDetailGetByIdQuery(int ıd)
    {
        Id = ıd;
    }

    public class BankAccountDetailedGetByIdQueryHandler : IRequestHandler<BankAccountDetailGetByIdQuery, AccountDetailViewDTO>
    {
        private readonly IAccountStatementRepository _statementRepo;
        private readonly IAccountRepository _accRepo;
        private readonly UserManager<BasePerson> _userManager;
        private readonly ITransactionTypeRepository _transactionTypeRepo;
        private readonly IMapper _mapper;

        public BankAccountDetailedGetByIdQueryHandler(IAccountStatementRepository statementRepo, IAccountRepository accRepo, UserManager<BasePerson> userManager, ITransactionTypeRepository transactionTypeRepo, IMapper mapper)
        {
            _statementRepo = statementRepo;
            _accRepo = accRepo;
            _userManager = userManager;
            _transactionTypeRepo = transactionTypeRepo;
            _mapper = mapper;
        }

        public async Task<AccountDetailViewDTO> Handle(BankAccountDetailGetByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accRepo.GetByIdAsync(request.Id);
            if (account is null)
                throw new ArgumentNullException("No account record found!");
            account.Customer = await _userManager.FindByIdAsync(account.CustomerId) as Customer;
            var accountStatementResult = await _statementRepo.GetAllAsync();
            var accountStatement = accountStatementResult.Where(statement => statement.CreatedById == request.Id).ToList();
            var statementList = _mapper.Map<List<TransactionDetail>>(accountStatement);
            var accountView = _mapper.Map<AccountDetailViewDTO>(account);
            accountView.TransactionList = statementList;
            return accountView;
        }
    }
}
