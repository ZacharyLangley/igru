using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Strains
{
    public class List
    {
        public class Query : IRequest<List<Strain>> { }
        public class Handler : IRequestHandler<Query, List<Strain>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Strain>> Handle(Query request, CancellationToken cancellationToken)
            {
                var strains = await _context.Strains.ToListAsync();

                return strains;
            }
        }
    }
}