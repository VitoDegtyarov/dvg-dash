using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvg.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task Delete(TEntity entityToDelete);
        Task<TEntity> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate);

    }
}
