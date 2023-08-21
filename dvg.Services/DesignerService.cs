using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.UnitOfWork;
using dvg.Dto;
using dvg.Services.Interfaces;
using Serilog;

namespace dvg.Services;

public class DesignerService : IDesignerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DesignerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<DesignerDto>> GetAllAsync()
    {
        var data = await _unitOfWork.DesignerRepository.GetAllAsync();

        var result = _mapper.Map<List<DesignerDto>>(data);

        return result;
    }

    public async Task<DesignerDto> GetByIdAsync(Guid id)
    {
        var data = await _unitOfWork.DesignerRepository.GetByIdAsync(id);

        var result = _mapper.Map<DesignerDto>(data);

        return result;
    }

    public async Task InsertAsync(DesignerDto? designer)
    {
        if (designer != null)
        {
            await _unitOfWork.DesignerRepository.InsertAsync(_mapper.Map<Designer>(designer));

            _logger.Information($"Added to database: Name:{designer.FirstName} - {designer.LastName}");
        }

        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteDesignerAsync(DesignerDto designerDto)
    {
        _unitOfWork.DesignerRepository.Delete(_mapper.Map<Designer>(designerDto));

        await _unitOfWork.SaveChanges();

        _logger.Information($"Remove from database: Name: {designerDto.FirstName} - {designerDto.LastName}");
    }
}