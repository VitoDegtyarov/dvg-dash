using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.UnitOfWork;
using dvg.Dto;
using dvg.Services.Interfaces;

namespace dvg.Services
{
    public class DesignerService : IDesignerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DesignerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
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

        public async Task InsertAsync(DesignerDto? designer)
        {
            if (designer != null)
            {
                await _unitOfWork.DesignerRepository.InsertAsync(_mapper.Map<Designer>(designer));
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteDesignerAsync(DesignerDto designerDTO)
        {
             _unitOfWork.DesignerRepository.Delete(_mapper.Map<Designer>(designerDTO));

            await _unitOfWork.SaveChanges();
        }
    }
}
