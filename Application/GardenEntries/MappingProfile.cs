using AutoMapper;
using Domain;

namespace Application.GardenEntries
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<GardenEntry, GardenEntryDto>();
        } 
    }
}