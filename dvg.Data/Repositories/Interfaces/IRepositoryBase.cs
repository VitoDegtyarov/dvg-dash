namespace dvg.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> DeleteAsync(Guid id);
        Task InsertAsync(TEntity entity);
        void  Update(TEntity entity);
        void SaveChanges();
    }
}