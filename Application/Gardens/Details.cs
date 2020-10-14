using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.Gardens
{
    public class Details
    {
        public class Query : IRequest<GardenDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GardenDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<GardenDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var garden = await _context.Gardens.FindAsync(request.Id);

                if (garden == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Garden = "Not found" });

                var mappedGarden = _mapper.Map<Garden, GardenDto>(garden);

                return mappedGarden;
            }
        }
    }
}