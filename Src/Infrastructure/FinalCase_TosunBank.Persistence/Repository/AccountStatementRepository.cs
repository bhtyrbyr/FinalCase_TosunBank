using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;

namespace FinalCase_TosunBank.Persistence.Repository;

internal class AccountStatementRepository : GenericRepository<AccountStatement, int>, IAccountStatementRepository
{
    public AccountStatementRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
    }
}
