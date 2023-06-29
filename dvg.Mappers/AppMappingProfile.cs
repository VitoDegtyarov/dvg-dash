using AutoMapper;
using dvg.Data.Entities;
using dvg.Services.DTO;

namespace dvg.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DesignerDTO, Designer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => new List<Project>()))
                .ReverseMap();

        }
    }
}