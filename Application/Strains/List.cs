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
        public class Query : IRequest<List<StrainDto>> { }
        public class Handler : IRequestHandler<Query, List<StrainDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,  IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<StrainDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var strains = await _context.Strains.ToListAsync();

                return _mapper.Map<List<Strain>, List<StrainDto>>(strains);
            }
        }
    }
}