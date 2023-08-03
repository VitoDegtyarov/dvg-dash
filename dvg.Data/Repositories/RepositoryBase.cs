using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace dvg.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
            _logger = Log.ForContext<RepositoryBase<TEntity>>();
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            LogInformation($"Create {typeof(TEntity).Name}");
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                LogError($"Error to create {typeof(TEntity).Name}", ex);
                throw;
            }
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

        protected void LogInformation(string message)
        {
            _logger.Information(message);
        }

        protected void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
    }
}
