namespace FinalCase_TosunBank.Application.Repository;

public interface IGenericRepository<T, IdType> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(IdType id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(IdType entity);
    Task CreateAsync(T entity);
}
