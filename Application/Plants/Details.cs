using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.Plants
{
    public class Details
    {
        public class Query : IRequest<PlantDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PlantDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<PlantDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var plant = await _context.Plants.FindAsync(request.Id);

                if (plant == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Plant = "Not found" });

                var mappedPlant = _mapper.Map<Plant, PlantDto>(plant);

                return mappedPlant;
            }
        }
    }
}