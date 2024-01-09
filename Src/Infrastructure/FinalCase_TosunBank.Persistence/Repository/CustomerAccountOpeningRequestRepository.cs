using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Repository;

public class CustomerAccountOpeningRequestRepository : GenericRepository<CustomerAccountOpeningRequest, int>, ICustomerAccountOpeningRequestRepository
{
    private readonly TosunBankDbContext _dbContext;
    public CustomerAccountOpeningRequestRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerAccountOpeningRequest> FindByNationalityNumberAsync(string NationalityNumber)
    {
        var result = await _dbContext.Set<CustomerAccountOpeningRequest>().Where(entity => entity.NationalityNumber == NationalityNumber).FirstOrDefaultAsync();
        return result;
    }
}
