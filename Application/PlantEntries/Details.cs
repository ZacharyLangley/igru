using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.PlantEntries
{
    public class Details
    {
        public class Query : IRequest<PlantEntryDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PlantEntryDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<PlantEntryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var plantEntry = await _context.PlantEntries.FindAsync(request.Id);

                if (plantEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { PlantEntry = "Not found" });
                
                var mappedPlantEntry = _mapper.Map<PlantEntry, PlantEntryDto>(plantEntry);
                
                return mappedPlantEntry;
            }
        } 
    }
}