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
        public class Query : IRequest<List<GardenEntryDto>> { }

        public class Handler : IRequestHandler<Query, List<GardenEntryDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<GardenEntryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var mappedGardenEntries = await _context.GardenEntries.ToListAsync();

                return _mapper.Map<List<GardenEntry>, List<GardenEntryDto>>(mappedGardenEntries);   
            }
        }
    }
}