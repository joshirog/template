using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monkeylab.Templates.Application.Commons.Interfaces;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Infrastructure.Persistences.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly  DbSet<T> _db;
        
        protected Repository(DbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        
        public async Task<int> CountAsync(object id)
        {
            return await _db
                .AsNoTracking()
                .CountAsync(x => x.Id.Equals(id));
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db
                .AsNoTracking()
                .CountAsync(predicate);
        }

        public async Task<bool> AnyAsync(object id)
        {
            return await _db
                .AsNoTracking()
                .AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db
                .AsNoTracking()
                .AnyAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _db
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> GetFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<T> GetFindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }
        
        public async Task<BasePaginate<T>> GetPaginate(
            int pageIndex, 
            int pageSize,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IEnumerable<Expression<Func<T, object>>> includes = null
            )
        {
            var query = _db.AsQueryable();
            
            if (includes is not null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (filter is not null)
                query = query.Where(filter);

            if (orderBy is not null)
                query = orderBy(query);

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
    
            return BasePaginate.Response(pageIndex, pageSize, items);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(T[] entities)
        {
            await _db.AddRangeAsync(entities);
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(T[] entities)
        {
            _db.AttachRange(entities);
            _context.Entry(entities).State = EntityState.Modified;
            await Task.CompletedTask;
            return entities;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            _db.Remove(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<T> RemoveByIdAsync(object id)
        {
            var entity = await  _db.FindAsync(id);
            _db.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> RemoveRangeAsync(T[] entities)
        {
            _db.RemoveRange(entities);
            await Task.CompletedTask;
            return entities;
        }
    }
}