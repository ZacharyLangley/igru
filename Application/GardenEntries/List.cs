using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.GardenEntries
{
    public class List
    {
        public class Query : IRequest<List<GardenEntry>> { }

        public class Handler : IRequestHandler<Query, List<GardenEntry>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<GardenEntry>> Handle(Query request, CancellationToken cancellationToken)
            {
                var gardenEntries = await _context.GardenEntries.ToListAsync();

                return gardenEntries;
            }
        }
    }
}