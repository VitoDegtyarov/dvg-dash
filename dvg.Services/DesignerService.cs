using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using dvg.Dto;
using dvg.Services.Interfaces;
using Serilog;

namespace dvg.Services;

public class DesignerService : IDesignerService
{
    private readonly IDesignerRepository _designerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DesignerService(IDesignerRepository deisgnerRepository, IMapper mapper, ILogger logger)
    {
        _designerRepository = deisgnerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<DesignerDto>> GetAllAsync()
    {
        var data = await _designerRepository.GetAllAsync();

        var result = _mapper.Map<List<DesignerDto>>(data);

        _logger.Information($"Service Layer **** Show all designer");

        return result;
    }

    public async Task<DesignerDto> GetByIdAsync(Guid id)
    {
        var data = await _designerRepository.GetByIdAsync(id);

        var result = _mapper.Map<DesignerDto>(data);

        return result;
    }

    public async Task InsertAsync(DesignerDto? designer)
    {
        if (designer != null)
        {
            await _designerRepository.InsertAsync(_mapper.Map<Designer>(designer));

        }

        await _designerRepository.SaveChanges();
    }

    public async Task DeleteDesignerAsync(DesignerDto designerDto)
    {
        _designerRepository.Delete(_mapper.Map<Designer>(designerDto));

        await _designerRepository.SaveChanges();

    }
}