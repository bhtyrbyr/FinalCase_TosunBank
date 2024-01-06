using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;

namespace FinalCase_TosunBank.Persistence.Repository;

public class AccountRepository : GenericRepository<Account, int>, IAccountRepository
{
    public AccountRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
    }
}
