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
        public class Query : IRequest<List<PlantDto>> { }

        public class Handler : IRequestHandler<Query, List<PlantDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<PlantDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var plants = await _context.Plants.ToListAsync();

                return _mapper.Map<List<Plant>, List<PlantDto>>(plants);
            }
        }
    }
}