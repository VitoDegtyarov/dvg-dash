using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using dvg.Dto;
using dvg.Services.Interfaces;

namespace dvg.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<List<ClientDto>> GetAllAsync()
        {
            var data = await _clientRepository.GetAllAsync();
            
            List<ClientDto> result = _mapper.Map<List<ClientDto>>(data);

            return result;
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            var data = await _clientRepository.GetByIdAsync(id);

            var result = _mapper.Map<ClientDto>(data);

            return result;
        }

        public async Task InsertASync(ClientDto client)
        {
            if (client != null)
            {
                await _clientRepository.InsertAsync(_mapper.Map<Client>(client));

            }
        }

        
    }
}
