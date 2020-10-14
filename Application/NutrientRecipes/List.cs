using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;

namespace Application.NutrientRecipes
{
    public class List
    {
       public class Query : IRequest<List<NutrientRecipeDto>> { }

        public class Handler : IRequestHandler<Query, List<NutrientRecipeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<NutrientRecipeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var nutrientRecipes = await _context.NutrientRecipes.ToListAsync();

                return _mapper.Map<List<NutrientRecipe>, List<NutrientRecipeDto>>(nutrientRecipes); 
            }
        } 
    }
}