using Domain.Entities;


namespace Application.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
