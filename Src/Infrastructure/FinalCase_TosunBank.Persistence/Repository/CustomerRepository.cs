using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;

namespace FinalCase_TosunBank.Persistence.Repository;

public class CustomerRepository : GenericRepository<Customer, string>, ICustomerRepository
{
    public CustomerRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
    }
}
