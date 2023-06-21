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
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public async Task Delete(TEntity entityToDelete)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            _context.Set<TEntity>().Update(entityToUpdate);
        }
    }
}
