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

namespace Application.PlantEntries
{
    public class List
    {
        public class PlantEntriesEnvelope
        {
            public List<PlantEntryDto> PlantEntries { get; set; }
            public int PlantEntryCount { get; set; }
        }
        public class Query : IRequest<PlantEntriesEnvelope>
        {
            public Query(Guid plantId, int? limit, int? offset, DateTime? startDate)
            {
                PlantId = plantId;
                Limit = limit;
                Offset = offset;
                StartDate = startDate ?? DateTime.Now;
            }
            public Guid PlantId { get; set; }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public DateTime? StartDate { get; set; }
        }

        public class Handler : IRequestHandler<Query, PlantEntriesEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<PlantEntriesEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.PlantEntries
                    .Where(x => x.PlantId == request.PlantId)
                    .OrderBy(x => x.Created)
                    .AsQueryable();

                var plantEntries = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new PlantEntriesEnvelope
                {
                    PlantEntries = _mapper.Map<List<PlantEntry>, List<PlantEntryDto>>(plantEntries),
                    PlantEntryCount = queryable.Count()
                };
            }
        }
    }
}