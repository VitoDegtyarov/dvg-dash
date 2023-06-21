using AutoMapper;
using dvg.Data.Entities;
using dvg.Services.DTO;

namespace dvg.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DesignerDTO, Designer>().ReverseMap();
        }
    }
}