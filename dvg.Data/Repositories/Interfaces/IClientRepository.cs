using dvg.Data.Entities;

namespace dvg.Data.Repositories.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<Client> GetByIdAsync(Guid id);

    }
}
