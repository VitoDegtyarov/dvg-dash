using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.UnitOfWork;
using dvg.Dto;
using dvg.Services.Interfaces;
using Serilog;

namespace dvg.Services
{
    public class DesignerServices : IDesignerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DesignerServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            
        }

        public async Task<List<DesignerDto>> GetAllAsync()
        {
            var data = await _unitOfWork.DesignerRepository.GetAllAsync();

            List<DesignerDto> result = _mapper.Map<List<DesignerDto>>(data);

            return result;
        }

        public async Task<DesignerDto> GetByIdAsync(Guid id)
        {
            var data = await _unitOfWork.DesignerRepository.GetByIdAsync(id);

            var result = _mapper.Map<DesignerDto>(data);

            return result;
        }

        public async Task InsertAsync(DesignerDto? designerDTO)
        {
            if (designerDTO != null)
            {
                await _unitOfWork.DesignerRepository.InsertAsync(_mapper.Map<Designer>(designerDTO));

                _logger.Information($"Added to DB:  Name:{designerDTO.FirstName} - {designerDTO.LastName}");
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteDesignerAsync(DesignerDto designerDTO)
        {
             _unitOfWork.DesignerRepository.Delete(_mapper.Map<Designer>(designerDTO));

            await _unitOfWork.SaveChanges();

            _logger.Information($"Delete from DB: Name: {designerDTO.FirstName} - {designerDTO.LastName}");
        }
    }
}
