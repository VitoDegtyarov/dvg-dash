using AutoMapper;
using dvg.Data.Entities;
using dvg.Data.Repositories;
using dvg.Data.Repositories.Interfaces;
using dvg.Data.UnitOfWork;
using dvg.Services.DTO;
using dvg.Services.Interfaces;

namespace dvg.Services
{
    public class DesignerServices : IDesignerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DesignerServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            await _unitOfWork.DesignerRepository.InsertAsync(_mapper.Map<Designer>(designerDTO));

            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteDesignerAsync(DesignerDTO designerDTO)
        {
            _unitOfWork.DesignerRepository.Delete(_mapper.Map<Designer>(designerDTO));

            await _unitOfWork.SaveChanges();
        }


    }
}
