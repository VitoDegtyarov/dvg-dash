using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.UnitOfWork;
using dvg.Services.DTO;
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

        public async Task<List<DesignerDTO>> GetAllAsync()
        {
            var data = await _unitOfWork.DesignerRepository.GetAllAsync();

            List<DesignerDTO> result = _mapper.Map<List<DesignerDTO>>(data);

            return result;
        }

        public async Task<DesignerDTO> GetByIdAsync(Guid id)
        {
            var data = await _unitOfWork.DesignerRepository.GetByIdAsync(id);

            var result = _mapper.Map<DesignerDTO>(data);

            return result;
        }

        public async Task InsertAsync(DesignerDTO? designerDTO)
        {
            if (designerDTO != null)
            {
                await _unitOfWork.DesignerRepository.InsertAsync(_mapper.Map<Designer>(designerDTO));

                _logger.Information($"Added to DB:  Name:{designerDTO.FirstName} - {designerDTO.LastName}");
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteDesignerAsync(DesignerDTO designerDTO)
        {
             _unitOfWork.DesignerRepository.Delete(_mapper.Map<Designer>(designerDTO));

            await _unitOfWork.SaveChanges();

            _logger.Information($"Delete from DB: Name: {designerDTO.FirstName} - {designerDTO.LastName}");
        }
    }
}
