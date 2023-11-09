using dvg.Core.Exceptions;
using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace dvg.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        protected RepositoryBase(ApplicationContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        //public async Task<TEntity> GetByIdAsync(Guid id)
        //{
        //    _logger.Information($"\tTry to get entity with id {id}");

        //    var entity = await _context.Set<TEntity>().FindAsync(id);

        //    if (entity != null)
        //    {
        //        _logger.Information($"\tEntity with id: {id} retrieved: {entity != null}");
        //        return entity;
        //    }
        //    else
        //    {
        //        _logger.Information($"Cannot find entity with id: {id}");
        //        return null;
        //    }
        //}

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entityToUpdate)
        {

            try
            {
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (RepositoryException ex)
            {
                _logger.Information("\n**** Error! ****");
                _logger.Information($"\n**** Source: {ex.Source}");
                _logger.Information($"\n**** Entity: {ex.EntityName}");
                _logger.Information($"\n**** Message: {ex.Message}");
                _logger.Information($"\n**** Method: {ex.StackTrace}");
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}