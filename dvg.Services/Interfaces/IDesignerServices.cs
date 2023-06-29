using dvg.Services.DTO;

namespace dvg.Services.Interfaces
{
    public interface IDesignerServices
    {
        Task InsertAsync(DesignerDTO designer);

        Task<List<DesignerDTO>> GetAllAsync();
        Task<DesignerDTO> GetByIdAsync(Guid id);
    }
}
