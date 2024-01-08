﻿namespace FinalCase_TosunBank.Application.Repository;

public interface IGenericRepository<T, IdType> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(IdType id);
    void UpdateAsync(T entity);
    void DeleteAsync(IdType entity);
    void CreateAsync(T entity);
}
