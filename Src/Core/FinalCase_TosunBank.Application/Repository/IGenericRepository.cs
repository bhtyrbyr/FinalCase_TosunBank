namespace FinalCase_TosunBank.Application.Repository;

public interface IGenericRepository<T, IdType> where T : class
{
    Task<List<T>> GetAll();
    Task<T> Get(IdType id);
    void Update(T entity);
    void Delete(IdType entity);
    void Create(T entity);
}
