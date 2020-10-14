using AutoMapper;
using Domain;

namespace Application.Strains
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Strain, StrainDto>();
        }
    }
}