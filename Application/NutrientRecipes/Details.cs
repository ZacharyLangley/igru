using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.NutrientRecipes
{
    public class Details
    {
        public class Query : IRequest<NutrientRecipe>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, NutrientRecipe>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<NutrientRecipe> Handle(Query request, CancellationToken cancellationToken)
            {
                var nutrientRecipe = await _context.NutrientRecipes.FindAsync(request.Id);

                if (nutrientRecipe == null)
                    throw new RestException(HttpStatusCode.NotFound, new { NutrientRecipe = "Not found" });

                return nutrientRecipe;
            }
        }
    }
}