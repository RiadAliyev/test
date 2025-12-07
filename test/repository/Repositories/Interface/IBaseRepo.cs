using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.common;

namespace repository.Repositories.Interface
{
    public interface IBaseRepo<T> where T : BaseEntyti
    {
        Task<int> SaveChanges();
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllWithIcludesAsync(params Expression<Func<T, object>>[] includes);
        Task<bool> CheckDataWithExpression(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAllWithIncludes();
        Task<IEnumerable<T>> GetAllWithIncludesAndExpressionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    }
}
