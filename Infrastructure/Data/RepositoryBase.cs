using System.Linq.Expressions;
using Core;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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

            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

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

        // protected IQueryable<TEntity> ListAll(Pagination pagination = null)
        // {
        //     var query = _context.Set<TEntity>().AsQueryable();

        //     if (pagination != null)
        //     {
        //         query = query.Skip(pagination.PageSize * (pagination.PageIndex - 1)).Take(pagination.PageSize);
        //     }
        //     return query;
        // }


    }
}