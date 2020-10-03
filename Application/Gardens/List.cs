using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Gardens
{
    public class List
    {
        public class Query : IRequest<List<Garden>> { }

        public class Handler : IRequestHandler<Query, List<Garden>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Garden>> Handle(Query request, CancellationToken cancellationToken)
            {
                var gardens = await _context.Gardens.ToListAsync();

                return gardens;
            }
        }
    }
}