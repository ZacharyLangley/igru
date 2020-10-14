using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.NutrientRecipes
{
    public class Details
    {
        public class Query : IRequest<NutrientRecipeDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, NutrientRecipeDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<NutrientRecipeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var nutrientRecipe = await _context.NutrientRecipes.FindAsync(request.Id);

                if (nutrientRecipe == null)
                    throw new RestException(HttpStatusCode.NotFound, new { NutrientRecipe = "Not found" });
                
                var mappedNutrientRecipe = _mapper.Map<NutrientRecipe, NutrientRecipeDto>(nutrientRecipe);

                return mappedNutrientRecipe;
            }
        }
    }
}