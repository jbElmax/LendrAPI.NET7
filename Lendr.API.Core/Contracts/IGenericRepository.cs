using Lendr.API.Core.Models;
using Microsoft.Build.Execution;

namespace Lendr.API.Core.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);

        Task<TResult> GetAsync<TResult>(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<TResult>> GetAllAsync<TResult>();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);

        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task UpdateAsync(T entity);

        Task UpdateAsync<TSource>(int id, TSource source);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
