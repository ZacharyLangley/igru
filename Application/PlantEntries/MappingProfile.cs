using AutoMapper;
using Domain;

namespace Application.PlantEntries
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<PlantEntry, PlantEntryDto>();
        }
    }
}