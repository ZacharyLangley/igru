using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Gardens
{
    public class Details
    {
        public class Query : IRequest<Garden>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Garden>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Garden> Handle(Query request, CancellationToken cancellationToken)
            {
                var garden = await _context.Gardens.FindAsync(request.Id);

                if (garden == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Garden = "Not found" });

                return garden;
            }
        }
    }
}