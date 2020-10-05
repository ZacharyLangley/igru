using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.PlantEntries
{
    public class List
    {
        public class Query : IRequest<List<PlantEntry>> { }

        public class Handler : IRequestHandler<Query, List<PlantEntry>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<PlantEntry>> Handle(Query request, CancellationToken cancellationToken)
            {
                var plantEntries = await _context.PlantEntries.ToListAsync();

                return plantEntries;
            }
        }
    }
}