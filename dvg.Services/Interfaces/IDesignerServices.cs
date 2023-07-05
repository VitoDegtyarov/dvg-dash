using dvg.Dto;

namespace dvg.Services.Interfaces
{
    public interface IDesignerServices
    {
        Task InsertAsync(DesignerDto designer);

        Task<List<DesignerDto>> GetAllAsync();
        Task<DesignerDto> GetByIdAsync(Guid id);
    }
}
