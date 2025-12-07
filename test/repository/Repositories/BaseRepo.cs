using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.common;
using Microsoft.EntityFrameworkCore;
using repository.Data;
using repository.Repositories.Interface;

namespace repository.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntyti
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate is null ? await _dbSet.ToListAsync() : await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIcludesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

    

        public async Task<T> GetWithExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }


        public async Task<bool> CheckDataWithExpression(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null) return false;

            return true;
        }


        public async Task<IEnumerable<T>> GetAllWithIncludesAndExpressionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public IQueryable<T> FindAllWithIncludes()
        {
            return _dbSet.AsQueryable();
        }
    }
}
