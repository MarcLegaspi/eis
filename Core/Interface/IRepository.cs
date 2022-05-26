using System.Linq.Expressions;

namespace Core.Interface
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);        
        Task<TEntity> GetByIdIncludingAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IReadOnlyList<TEntity>> ListAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IReadOnlyList<TEntity>> ListAllIncludingAsync(Pagination pagination,params Expression<Func<TEntity, object>>[] includeProperties);
        void DeleteAsync(TEntity entity);
    }
}