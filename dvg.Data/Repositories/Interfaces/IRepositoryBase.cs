namespace dvg.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        void Delete(TEntity entityToDelete);
        Task InsertAsync(TEntity entity);
        void UpdateAsync(TEntity entityToUpdate);
    }
}
