using Core;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity:BaseEntity
    {
        private readonly EisContext _context;
        public RepositoryBase(EisContext context)
        {
            _context = context;            
        }
        public async Task<TEntity>  CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
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

            if(pagination != null) {
                query = query.Skip(pagination.PageSize * (pagination.PageIndex - 1)).Take(pagination.PageSize);
            }
            return query;
        }
    }
}