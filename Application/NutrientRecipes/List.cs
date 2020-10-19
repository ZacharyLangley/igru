using System;
using System.Linq;
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
       public class NutrientRecipeEnvelope
       {
           public List<NutrientRecipeDto> NutrientRecipes { get; set; }
           public int NutrientRecipeCount { get; set; }
       }
       public class Query : IRequest<NutrientRecipeEnvelope>
       {
            public Query(int? limit, int? offset, DateTime? startDate)
            {
                Limit = limit;
                Offset = offset;
                StartDate = startDate ?? DateTime.Now;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public DateTime? StartDate { get; set; }
       }

        public class Handler : IRequestHandler<Query, NutrientRecipeEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<NutrientRecipeEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.NutrientRecipes
                    .OrderBy(x => x.Name)
                    .AsQueryable();

                var nutrientRecipes = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new NutrientRecipeEnvelope
                {
                    NutrientRecipes = _mapper.Map<List<NutrientRecipe>, List<NutrientRecipeDto>>(nutrientRecipes),
                    NutrientRecipeCount = queryable.Count()
                };
            }
        } 
    }
}