using AutoMapper;
using dvg.Data.Entities;
using dvg.Dto;

namespace dvg.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DesignerDto, Designer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => new List<Project>()))
                .ReverseMap();

            CreateMap<ClientDto, Client>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ReverseMap();

        }
    }
}