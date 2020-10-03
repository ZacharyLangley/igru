using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.GardenEntries
{
    public class Details
    {
        public class Query : IRequest<GardenEntry>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GardenEntry>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<GardenEntry> Handle(Query request, CancellationToken cancellationToken)
            {
                var gardenEntry = await _context.GardenEntries.FindAsync(request.Id);

                if (gardenEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { GardenEntry = "Not found" });

                return gardenEntry;
            }
        }
    }
}