using AutoMapper;
using dvg.Data.Entities;
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
        public async Task InsertAsync(DesignerDTO designerDTO)
        {
            var designerEntity = _mapper.Map<Designer>(designerDTO);

            await _unitOfWork.DesignerRepository.InsertAsync(designerEntity);

            _unitOfWork.SaveChanges();

        }


    }
}
