using dvg.Data.Entities;

namespace dvg.Data.Repositories.Interfaces
{
    public interface IDesignerRepository : IRepositoryBase<Designer>
    {
        Task InsertAsync(Designer entity);
    }
}
