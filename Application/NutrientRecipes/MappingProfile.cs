using AutoMapper;
using Domain;

namespace Application.NutrientRecipes
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<NutrientRecipe, NutrientRecipeDto>();
        }
    }
}