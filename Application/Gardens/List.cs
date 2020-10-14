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
        public class Query : IRequest<List<GardenDto>> { }

        public class Handler : IRequestHandler<Query, List<GardenDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<GardenDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var mappedGardens = await _context.Gardens.ToListAsync();

                return _mapper.Map<List<Garden>, List<GardenDto>>(mappedGardens);            }
        }
    }
}