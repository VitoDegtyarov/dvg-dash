using dvg.Core.UpdateModels;
using dvg.Dto;

namespace dvg.Services.Interfaces
{
    public interface IDesignerService
    {
        Task InsertAsync(DesignerDto designer);

        Task<List<DesignerDto>> GetAllAsync();
        Task<DesignerDto> GetByIdAsync(Guid id);
        Task DeleteDesignerAsync(Guid id);
        Task UpdateDesignerAsync(Guid id, DesignerUpdateModel updateModel);
    }
}
