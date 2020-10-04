using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.NutrientRecipes
{
    public class List
    {
       public class Query : IRequest<List<NutrientRecipe>> { }

        public class Handler : IRequestHandler<Query, List<NutrientRecipe>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<NutrientRecipe>> Handle(Query request, CancellationToken cancellationToken)
            {
                var nutrientRecipe = await _context.NutrientRecipes.ToListAsync();

                return nutrientRecipe;
            }
        } 
    }
}