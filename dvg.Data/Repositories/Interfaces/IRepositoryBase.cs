namespace dvg.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task Delete(TEntity entityToDelete);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate);

    }
}
