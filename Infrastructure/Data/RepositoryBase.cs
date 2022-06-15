using System.Linq.Expressions;
using Core;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EisContext _context;
        public RepositoryBase(EisContext context)
        {
            _context = context;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> CountAsync()
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (_criteria != null)
            {
                query = query.Where(_criteria);
            }

            return await query.CountAsync();
        }

        public async Task<TEntity> GetByIdIncludingAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }                        

            return await query.FirstOrDefaultAsync(m => (int)m.GetType().GetProperty("Id").GetValue(m,null) == id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync() {
            var query = _context.Set<TEntity>().AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (_criteria != null)
            {
                query = query.Where(_criteria);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAllIncludingAsync(Pagination pagination, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (_criteria != null)
            {
                query = query.Where(_criteria);
            }

            query = query.Skip(pagination.PageSize * (pagination.PageIndex - 1)).Take(pagination.PageSize);


            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        protected IQueryable<TEntity> ListAll(Pagination pagination = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (pagination != null)
            {
                query = query.Skip(pagination.PageSize * (pagination.PageIndex - 1)).Take(pagination.PageSize);
            }
            return query;
        }

        private Expression<Func<TEntity, bool>> _criteria;
        public void SetFilter(Expression<Func<TEntity, bool>> criteria)
        {
            _criteria = criteria;
        }
    }
}