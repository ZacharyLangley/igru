using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Plants
{
    public class Details
    {
        public class Query : IRequest<Plant>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Plant>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Plant> Handle(Query request, CancellationToken cancellationToken)
            {
                var plant = await _context.Plants.FindAsync(request.Id);

                if (plant == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Plant = "Not found" });

                return plant;
            }
        }
    }
}