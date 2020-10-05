using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.PlantEntries
{
    public class Details
    {
        public class Query : IRequest<PlantEntry>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PlantEntry>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<PlantEntry> Handle(Query request, CancellationToken cancellationToken)
            {
                var plantEntry = await _context.PlantEntries.FindAsync(request.Id);

                if (plantEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { PlantEntry = "Not found" });

                return plantEntry;
            }
        } 
    }
}