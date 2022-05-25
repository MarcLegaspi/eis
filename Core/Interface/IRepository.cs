namespace Core.Interface
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}