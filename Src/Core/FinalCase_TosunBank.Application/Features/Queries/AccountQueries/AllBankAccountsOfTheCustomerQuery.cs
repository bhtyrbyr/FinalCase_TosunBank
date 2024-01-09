using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.AccountDTOs;
using FinalCase_TosunBank.Application.Repository;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.AccountQueries;

public class AllBankAccountsOfTheCustomerQuery : IRequest<List<AccountSimplifiedViewDTO>>
{
    private readonly string CustomerId;

    public AllBankAccountsOfTheCustomerQuery(string customerId)
    {
        CustomerId = customerId;
    }

    public class AllBankAccountsOfTheCustomerQueryHandler : IRequestHandler<AllBankAccountsOfTheCustomerQuery, List<AccountSimplifiedViewDTO>>
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public AllBankAccountsOfTheCustomerQueryHandler(IAccountRepository accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<List<AccountSimplifiedViewDTO>> Handle(AllBankAccountsOfTheCustomerQuery request, CancellationToken cancellationToken)
        {
            var list = (await _accountRepo.GetAllAsync()).Where(account => account.CustomerId == request.CustomerId).ToList();
            if (!list.Any())
                return null;
            var result = _mapper.Map<List<AccountSimplifiedViewDTO>>(list);
            return result;
        }
    }
}
