using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Gardens
{
    public class Create
    {
        public class Command : IRequest
        {        
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Location { get; set; }
            public string GrowType { get; set; }
            public string GrowSize { get; set; }
            public string GrowStyle { get; set; }
            public string ContainerSize { get; set; }
            public string Tags { get; set; }
            public Guid Owner { get; set; }
            public string Editors { get; set; }
            public DateTime Created { get; set; }
            public DateTime LastUpdated { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Location).NotEmpty();
                RuleFor(x => x.GrowType).NotEmpty();
                RuleFor(x => x.GrowSize).NotEmpty();
                RuleFor(x => x.GrowStyle).NotEmpty();
                RuleFor(x => x.ContainerSize).NotEmpty();
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
                var garden = new Garden
                {
                    Name = request.Name,
                    Location = request.Location,
                    GrowType = request.GrowType,
                    GrowSize = request.GrowSize,
                    GrowStyle = request.GrowStyle,
                    ContainerSize = request.ContainerSize,
                    Tags = request.Tags,
                    Editors = request.Editors,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                };

                _context.Gardens.Add(garden);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}