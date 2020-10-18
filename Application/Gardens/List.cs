using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Gardens
{
    public class List
    {
        public class GardensEnvelope
        {
            public List<GardenDto> Gardens { get; set; }
            public int GardenCount { get; set; }
        }

        public class Query : IRequest<GardensEnvelope> 
        {
            public Query(int? limit, int? offset, DateTime? startDate)
            {
                Limit = limit;
                Offset = offset;
                StartDate = startDate ?? DateTime.Now;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public DateTime? StartDate { get; set; }
        }

        public class Handler : IRequestHandler<Query, GardensEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<GardensEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Gardens.AsQueryable();

                var gardens = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new GardensEnvelope
                {
                    Gardens = _mapper.Map<List<Garden>, List<GardenDto>>(gardens),
                    GardenCount = queryable.Count()
                };
            }
        }
    }
}