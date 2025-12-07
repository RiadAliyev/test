using System.Linq.Expressions;
using Domain.common;

namespace repository.Repositories.IRepositories;

public interface IBaseRepository<T> where T : BaseEntyti, new()
{
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetByFiltered(Expression<Func<T, bool>>? predicate = null,
                                Expression<Func<T, object>>[]? include = null,
                                bool IsTracking = false);
    IQueryable<T> GetAll(bool IsTracking = false);
    IQueryable<T> GetAllFiltered(Expression<Func<T, bool>>? predicate = null,
                         Expression<Func<T, object>>[]? include = null,
                         Expression<Func<T, object>>? orderBy = null,
                         bool IsOrderByAsc = true,
                         bool IsTracking = false);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);

    Task SaveChangeAsync();
}
