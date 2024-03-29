﻿using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Domain.Repository;
using FinalCase_TosunBank.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Repository;

public class NewCustomerAccountOpeningRequestRepository : GenericRepository<NewCustomerAccountOpeningRequest, int>, INewCustomerAccountOpeningRequestRepository
{
    private readonly TosunBankDbContext _dbContext;
    public NewCustomerAccountOpeningRequestRepository(TosunBankDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NewCustomerAccountOpeningRequest> FindByNationalityNumberAsync(string NationalityNumber)
    {
        var result = await _dbContext.Set<NewCustomerAccountOpeningRequest>().Where(entity => entity.NationalityNumber == NationalityNumber).FirstOrDefaultAsync();
        return result;
    }
}
