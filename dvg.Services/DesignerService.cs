using AutoMapper;
using dvg.Core.Exceptions;
using dvg.Core.UpdateModels;
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

    public DesignerService(IDesignerRepository designerRepository, IMapper mapper, ILogger logger)
    {
        _designerRepository = designerRepository;
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

        _designerRepository.SaveChanges();
    }

    public async Task DeleteDesignerAsync(Guid id)
    {
        await _designerRepository.DeleteAsync(id);
    }

    public async Task UpdateDesignerAsync(Guid id, DesignerUpdateModel updateModel)
    {
        try
        {

            if (!updateModel.IsEmpty())
            {
                var designer = await _designerRepository.GetByIdAsync(id);

                if (updateModel.FirstName != null)
                    designer.FirstName = updateModel.FirstName;

                if (updateModel.LastName != null)
                    designer.LastName = updateModel.LastName;

                if (updateModel.PhoneNumber != null)
                    designer.PhoneNumber = updateModel.PhoneNumber;

                if (updateModel.Position != null)
                    designer.Position = updateModel.Position.Value;

                _designerRepository.Update(designer);
            }
        }
        catch (RepositoryException ex)
        {
            _logger.Information("\n**** Error! ****");
            _logger.Information($"\n**** Source: {ex.Source}");
            _logger.Information($"\n**** Entity: {ex.EntityName}");
            _logger.Information($"\n**** Message: {ex.Message}");
            _logger.Information($"\n**** Method: {ex.StackTrace}");
        }
    }
}