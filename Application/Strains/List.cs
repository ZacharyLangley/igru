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

namespace Application.Strains
{
    public class List
    {
        public class StrainEnvelope
        {
            public List<StrainDto> Strains { get; set; }
            public int StrainCount { get; set; }
        }
        public class Query : IRequest<StrainEnvelope>
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
        public class Handler : IRequestHandler<Query, StrainEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<StrainEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Strains
                    .OrderBy(x => x.Name)
                    .AsQueryable();

                var strains = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 30)
                    .ToListAsync();

                return new StrainEnvelope
                {
                    Strains =  _mapper.Map<List<Strain>, List<StrainDto>>(strains),
                    StrainCount = queryable.Count()
                };
            }
        }
    }
}