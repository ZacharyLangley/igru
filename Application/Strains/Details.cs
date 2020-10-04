using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Strains
{
    public class Details
    {
        public class Query : IRequest<Strain>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Strain>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Strain> Handle(Query request, CancellationToken cancellationToken)
            {
                var strain = await _context.Strains.FindAsync(request.Id);

                if (strain == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Strain = "Not found" });

                return strain;
            }
        }
    }
}