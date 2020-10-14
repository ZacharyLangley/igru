using AutoMapper;
using Domain;

namespace Application.Plants
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Plant, PlantDto>();
        }
    }
}