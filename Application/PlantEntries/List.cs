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
        public class Query : IRequest<List<PlantEntryDto>> { }

        public class Handler : IRequestHandler<Query, List<PlantEntryDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<PlantEntryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var plantEntries = await _context.PlantEntries.ToListAsync();

                return _mapper.Map<List<PlantEntry>, List<PlantEntryDto>>(plantEntries);
            }
        }
    }
}