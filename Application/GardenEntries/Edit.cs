using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.GardenEntries
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid GardenId { get; set; }
            public string Title { get; set; }
            public string Comment { get; set; }
            public string Tags { get; set; }
            public string Temperature { get; set; }
            public double Humidity { get; set; }
            public string LightLevel { get; set; }
            public Guid Owner { get; set; }
            public string Editors { get; set; }
            public DateTime Created { get; set; }
            public DateTime LastUpdated { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.GardenId).NotEmpty();
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Temperature).NotEmpty();
                RuleFor(x => x.Humidity).NotEmpty();
                RuleFor(x => x.LightLevel).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var gardenEntry = await _context.GardenEntries.FindAsync(request.Id);

                if (gardenEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Garden = "Not found" });

                gardenEntry.Title = request.Title ?? gardenEntry.Title;
                gardenEntry.Comment = request.Comment ?? gardenEntry.Comment;
                gardenEntry.Tags = request.Tags ?? gardenEntry.Tags;
                gardenEntry.Temperature = request.Temperature ?? gardenEntry.Temperature;
                gardenEntry.Humidity = request.Humidity;
                gardenEntry.LightLevel = request.LightLevel ?? gardenEntry.LightLevel;
                gardenEntry.Editors = request.Editors ?? gardenEntry.Editors;
                gardenEntry.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}