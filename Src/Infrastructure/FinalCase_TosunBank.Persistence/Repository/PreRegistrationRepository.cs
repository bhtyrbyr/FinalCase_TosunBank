using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Repository;

public class PreRegistrationRepository : GenericRepository<PreRegistration, int>, IPreRegistrationRepository
{
    private readonly TosunBankDbContext _dbContext;
    public PreRegistrationRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PreRegistration> FindByNationalityNumberAsync(string NationalityNumber)
    {
        var result = await _dbContext.Set<PreRegistration>().Where(entity => entity.NationalityNumber == NationalityNumber).FirstOrDefaultAsync();
        return result;
    }
}
