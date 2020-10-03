using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Plants
{
    public class List
    {
        public class Query : IRequest<List<Plant>> { }

        public class Handler : IRequestHandler<Query, List<Plant>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Plant>> Handle(Query request, CancellationToken cancellationToken)
            {
                var plants = await _context.Plants.ToListAsync();

                return plants;
            }
        }
    }
}