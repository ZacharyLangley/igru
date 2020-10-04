using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.NutrientRecipes
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Instructions { get; set; }
            public string PH { get; set; }
            public string MixTime { get; set; }
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
                var nutrientRecipe = new NutrientRecipe
                {
                    Name = request.Name,
                    Comment = request.Comment,
                    Instructions = request.Instructions,
                    PH = request.PH,
                    MixTime = request.MixTime,
                    Tags = request.Tags,
                    Owner = request.Owner,
                    Editors = request.Editors,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                };

                _context.NutrientRecipes.Add(nutrientRecipe);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}