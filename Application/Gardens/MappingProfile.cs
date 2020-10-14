using AutoMapper;
using Domain;

namespace Application.Gardens
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Garden, GardenDto>();
        }
    }
}