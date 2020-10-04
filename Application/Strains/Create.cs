using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Strains
{
    public class Create
    {
        public class Command : IRequest
        {   
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Notes { get; set; }
            public DateTime Aquired { get; set; }
            public double Price { get; set; }
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
                var strain = new Strain
                {
                    Name = request.Name,
                    Comment = request.Comment,
                    Notes = request.Notes,
                    Aquired = request.Aquired,
                    Price = request.Price,
                    ThcPercentage = request.ThcPercentage,
                    CbdPercentage = request.CbdPercentage,
                    Parentage = request.Parentage,
                    Aroma = request.Aroma,
                    Taste = request.Taste,
                    Tags = request.Tags,
                    Editors = request.Editors,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                };

                _context.Strains.Add(strain);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}