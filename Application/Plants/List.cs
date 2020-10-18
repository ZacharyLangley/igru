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

namespace Application.Plants
{
    public class List
    {
        public class PlantsEnvelope
        {
            public List<PlantDto> Plants { get; set; }
            public int PlantCount { get; set; }
        }

        public class Query : IRequest<PlantsEnvelope>
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

        public class Handler : IRequestHandler<Query, PlantsEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<PlantsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Plants.AsQueryable();

                var plants = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new PlantsEnvelope {
                    Plants = _mapper.Map<List<Plant>, List<PlantDto>>(plants),
                    PlantCount = queryable.Count()
                };
            }
        }
    }
}