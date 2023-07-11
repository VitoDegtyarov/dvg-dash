using dvg.Dto;

namespace dvg.Services.Interfaces
{
    public interface IDesignerService
    {
        Task InsertAsync(DesignerDto designer);

        Task<List<DesignerDto>> GetAllAsync();
        Task<DesignerDto> GetByIdAsync(Guid id);
    }
}
