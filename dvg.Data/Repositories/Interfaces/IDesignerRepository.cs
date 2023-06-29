using dvg.Data.Entities;

namespace dvg.Data.Repositories.Interfaces
{
    public interface IDesignerRepository : IRepositoryBase<Designer>
    {
        Task<Designer> GetByIdAsync(Guid id);
        Task InsertAsync(Designer entity);
    }
}
