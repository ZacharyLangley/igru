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

namespace Application.PlantEntries
{
    public class Edit
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
                var plantEntry = await _context.PlantEntries.FindAsync(request.Id);

                if (plantEntry == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Plant = "Not found" });

                plantEntry.PlantId = request.PlantId;
                plantEntry.NutrientRecipeId = request.NutrientRecipeId;;
                plantEntry.Title = request.Title ?? plantEntry.Title;
                plantEntry.Comment = request.Comment ?? plantEntry.Comment;
                plantEntry.SoilSaturation = request.SoilSaturation;
                plantEntry.PH = request.PH;
                plantEntry.Height = request.Height ?? plantEntry.Height;
                plantEntry.BudTrichomeColor = request.BudTrichomeColor ?? plantEntry.BudTrichomeColor;
                plantEntry.GrowState = request.GrowState ?? plantEntry.GrowState;
                plantEntry.ColaSize = request.ColaSize ?? plantEntry.ColaSize;
                plantEntry.AverageBudSize = request.AverageBudSize ?? plantEntry.AverageBudSize;
                plantEntry.StalkDiameter = request.StalkDiameter ?? plantEntry.StalkDiameter;
                plantEntry.Tags = request.Tags ?? plantEntry.Tags;
                plantEntry.Editors = request.Editors ?? plantEntry.Editors;
                plantEntry.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}