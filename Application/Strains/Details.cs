using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.Strains
{
    public class Details
    {
        public class Query : IRequest<StrainDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StrainDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }


            public async Task<StrainDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var strain = await _context.Strains.FindAsync(request.Id);

                if (strain == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Strain = "Not found" });

                var mappedStrain = _mapper.Map<Strain, StrainDto>(strain);

                return mappedStrain;
            }
        }
    }
}