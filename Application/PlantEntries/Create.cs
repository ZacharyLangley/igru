using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.PlantEntries
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid PlantId { get; set; }
            public Guid NutrientRecipeId { get; set; }
            public string Title { get; set; }
            public string Comment { get; set; }
            public double SoilSaturation { get; set; }
            public double PH { get; set; }
            public string Height { get; set; }
            public string BudTrichomeColor { get; set; }
            public string GrowState { get; set; }
            public string ColaSize { get; set; }
            public string AverageBudSize { get; set; }
            public string StalkDiameter { get; set; }
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
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PlantId).NotEmpty();
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
                var plantEntry = new PlantEntry
                {
                    PlantId = request.PlantId,
                    NutrientRecipeId = request.NutrientRecipeId,
                    Title = request.Title,
                    Comment = request.Comment,
                    SoilSaturation = request.SoilSaturation,
                    PH = request.PH,
                    Height = request.Height,
                    BudTrichomeColor = request.BudTrichomeColor,
                    GrowState = request.GrowState,
                    ColaSize = request.ColaSize,
                    AverageBudSize = request.AverageBudSize,
                    StalkDiameter = request.StalkDiameter,
                    Tags = request.Tags,
                    Editors = request.Editors,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                };

                _context.PlantEntries.Add(plantEntry);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}