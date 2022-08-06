using ECommerce.Data.Contexts;
using ECommerce.Domain.Contracts.Repository;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly Lazy<DbSet<TEntity>> _dbSet;
        protected readonly ECommerceContext _context;

        public RepositoryBase(ECommerceContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbSet = new Lazy<DbSet<TEntity>>(() => dbContext.Set<TEntity>());
            _context = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var added = await _dbSet.Value.AddAsync(entity, cancellationToken);
            return added.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.Value.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.Value.AsQueryable().Where(predicate).AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);

            return await query.CountAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            var query = FilterAndOrder<object>(null, null, true, null);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString<object>(null, null, true, null, includesString);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder<object>(null, null, true, null, includes);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString<object>(predicate, null, true, null, includesString);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null, includes);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null, includes);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null, includes);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var query = FilterAndOrder<object>(null, null, true, null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString<object>(null, null, true, null, includesString);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder<object>(null, null, true, null, includes);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString<object>(predicate, null, true, null, includesString);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null, includes);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, int? take, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, take, includes);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString(null, orderByKeySelector, orderAscending, null, includesString);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null, includes);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString(predicate, orderByKeySelector, orderAscending, null, includesString);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null, includes);

            return await query.ToListAsync();
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            return await GetPaginatedAsync(null, page, pageSize, orderByKeySelector, orderAscending, includes: null);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes)
        {
            return await GetPaginatedAsync(null, page, pageSize, orderByKeySelector, orderAscending, includes: includes);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString)
        {
            return await GetPaginatedAsync(null, page, pageSize, orderByKeySelector, orderAscending, includesString: includesString);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            return await GetPaginatedAsync(predicate, page, pageSize, orderByKeySelector, orderAscending, includes: null);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, string[] includesString)
        {
            var query = FilterAndOrderWithIncludeString(predicate, orderByKeySelector, orderAscending, null, includesString);

            var items = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            var total = await query.CountAsync();

            return new PaginatedList<TEntity>(items, total, page, pageSize);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, Expression<Func<TEntity, object>>[] includes)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null, includes);

            var items = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            var total = await query.CountAsync();

            return new PaginatedList<TEntity>(items, total, page, pageSize);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Value.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.Value.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            var added = _dbSet.Value.Update(entity);

            return added.Entity;
        }

        private IQueryable<TEntity> FilterAndOrder<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, int? take, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Value.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderByKeySelector != null)
            {
                if (orderAscending)
                {
                    query = query.OrderBy(orderByKeySelector);
                }
                else
                {
                    query = query.OrderByDescending(orderByKeySelector);
                }
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (take != null && take != 0)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        private IQueryable<TEntity> FilterAndOrderWithIncludeString<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, int? take, params string[] includes)
        {
            var query = _dbSet.Value.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderByKeySelector != null)
            {
                if (orderAscending)
                {
                    query = query.OrderBy(orderByKeySelector);
                }
                else
                {
                    query = query.OrderByDescending(orderByKeySelector);
                }
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (take != null && take != 0)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
