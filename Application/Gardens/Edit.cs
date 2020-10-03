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

namespace Application.Gardens
{
    public class Edit
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
            public DateTime LastUpdated { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Comment).NotEmpty();
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
                var garden = await _context.Gardens.FindAsync(request.Id);

                if (garden == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Garden = "Not found" });

                garden.Name = request.Name ?? garden.Name;
                garden.Comment = request.Comment ?? garden.Comment;
                garden.Location = request.Location ?? garden.Location;
                garden.GrowType = request.GrowType ?? garden.GrowType;
                garden.GrowSize = request.GrowSize ?? garden.GrowSize;
                garden.GrowStyle = request.GrowStyle ?? garden.GrowStyle;
                garden.ContainerSize = request.ContainerSize ?? garden.ContainerSize;
                garden.Tags = request.Tags ?? garden.Tags;
                garden.Editors = request.Editors ?? garden.Editors;
                garden.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}