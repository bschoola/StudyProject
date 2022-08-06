using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Domain.Contracts.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> FirstOrDefaultAsync();

        Task<TEntity> FirstOrDefaultAsync(params string[] includesString);

        Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params string[] includesString);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<IEnumerable<TEntity>> GetAsync(params string[] includesString);

        Task<IEnumerable<TEntity>> GetAsync(params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includesString);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TField>> orderByKeySelector = null, bool orderAscending = true, int? take = null, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString);

        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params Expression<Func<TEntity, object>>[] includes);

        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, params string[] includesString);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
