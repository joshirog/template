using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Application.Commons.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> CountAsync(object id);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        
        Task<bool> AnyAsync(object id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T>GetFindAsync(Expression<Func<T, bool>> predicate);

        Task<BasePaginate<T>> GetPaginate(
            int page,
            int pageSize,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IEnumerable<Expression<Func<T, object>>> includes = null
        );

        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(T[] entities);

        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateRangeAsync(T[] entities);

        Task<T> RemoveAsync(T entity);
        Task<T> RemoveByIdAsync(object id);
        Task<IEnumerable<T>> RemoveRangeAsync(T[] entities);
    }
}