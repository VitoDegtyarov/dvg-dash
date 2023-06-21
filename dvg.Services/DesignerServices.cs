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
        public async Task Create(DesignerDTO designerDTO)
        {
            await _unitOfWork.Designer.InsertAsync(_mapper.Map<Designer>(designerDTO));
        }
    }
}
