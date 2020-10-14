using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.GardenEntries
{
    public class Details
    {
        public class Query : IRequest<GardenEntryDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GardenEntryDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<GardenEntryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var gardenEntry = await _context.GardenEntries.FindAsync(request.Id);

                if (gardenEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { GardenEntry = "Not found" });

                var mappedGarden = _mapper.Map<GardenEntry, GardenEntryDto>(gardenEntry);
                return mappedGarden;
            }
        }
    }
}