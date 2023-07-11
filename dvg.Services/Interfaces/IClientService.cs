using dvg.Dto;

namespace dvg.Services.Interfaces
{
    public interface IClientService
    {
        Task InsertASync(ClientDto client);
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(Guid id);

    }
}
