using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dvg.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public void Delete(TEntity entityToDelete)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void UpdateAsync(TEntity entityToUpdate)
        {
            _context.Set<TEntity>().Update(entityToUpdate);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
