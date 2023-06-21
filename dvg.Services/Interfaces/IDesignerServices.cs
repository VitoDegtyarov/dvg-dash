using dvg.Services.DTO;

namespace dvg.Services.Interfaces
{
    public interface IDesignerServices
    {
        Task Create(DesignerDTO designer);
    }
}
