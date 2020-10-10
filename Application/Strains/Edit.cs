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

namespace Application.Strains
{
    public class Edit
    {
        public class Command : IRequest
        {   
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Notes { get; set; }
            public DateTime? Aquired { get; set; }
            public double? Price { get; set; }
            public double ThcPercentage { get; set; }
            public double CbdPercentage { get; set; }
            public string Parentage { get; set; }
            public string Aroma { get; set; }
            public string Taste { get; set; }
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
                var strain = await _context.Strains.FindAsync(request.Id);

                if (strain == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Strain = "Not found" });

                strain.Name = request.Name ?? strain.Name;
                strain.Comment = request.Comment ?? strain.Comment;
                strain.Notes = request.Notes ?? strain.Notes;
                strain.Aquired = request.Aquired ?? strain.Aquired;
                strain.Price = request.Price ?? strain.Price;
                strain.ThcPercentage = request.ThcPercentage;
                strain.CbdPercentage = request.CbdPercentage;
                strain.Parentage = request.Parentage ?? strain.Parentage;
                strain.Aroma = request.Aroma ?? strain.Aroma;
                strain.Taste = request.Taste ?? strain.Taste;
                strain.Tags = request.Tags ?? strain.Tags;
                strain.Editors = request.Editors ?? strain.Editors;
                strain.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}