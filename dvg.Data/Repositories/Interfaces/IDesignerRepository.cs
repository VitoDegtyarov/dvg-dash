using dvg.Data.Entities;


namespace dvg.Data.Repositories.Interfaces
{
    public interface IDesignerRepository : IRepositoryBase<Designer>
    {
        Task<List<Designer>> GetAllDesignerAsync();
    }
}
