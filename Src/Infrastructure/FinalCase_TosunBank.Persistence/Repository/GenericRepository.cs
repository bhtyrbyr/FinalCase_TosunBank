using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Domain.Repository;

public class GenericRepository<T, IdType> : IGenericRepository<T, IdType> where T : class
{
    private readonly TosunBankDbContext _dbContext;

    public GenericRepository(TosunBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(IdType id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async void CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async void DeleteAsync(IdType entity)
    {
        var record = await _dbContext.Set<T>().FindAsync(entity);
        if(record is null)
        {
            throw new ArgumentNullException("No record found!");
        }
        _dbContext.Remove(record);
        await _dbContext.SaveChangesAsync();
    }

    public async void UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
