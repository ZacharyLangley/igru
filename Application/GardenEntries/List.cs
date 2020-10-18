using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;

namespace Application.GardenEntries
{
    public class List
    {
        public class GardenEntriesEnvelope
        {
            public List<GardenEntryDto> GardenEntries { get; set; }
            public int GardenEntryCount { get; set; }
        }
        public class Query : IRequest<GardenEntriesEnvelope>
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

        public class Handler : IRequestHandler<Query, GardenEntriesEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<GardenEntriesEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.GardenEntries.AsQueryable();

                var gardenEntries = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new GardenEntriesEnvelope
                {
                    GardenEntries = _mapper.Map<List<GardenEntry>, List<GardenEntryDto>>(gardenEntries),
                    GardenEntryCount = queryable.Count()
                };
            }
        }
    }
}