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

namespace Application.Plants
{
    public class Edit
    {
        public class Command : IRequest
        {        
            public Guid Id { get; set; }
            public Guid GardenId { get; set; }
            public Guid StrainId { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Notes { get; set; }
            public string GrowCycleLength { get; set; }
            public DateTime Aquired { get; set; }
            public string Parentage { get; set; }
            public string Origin { get; set; }
            public string Gender { get; set; }
            public double DaysFlowering { get; set; }
            public double DaysCured { get; set; }
            public string HarvestedWeight { get; set; }
            public double BudDensity { get; set; }
            public bool BudPistils { get; set; }
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
                RuleFor(x => x.GardenId).NotEmpty();
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
                var plant = await _context.Plants.FindAsync(request.Id);

                if (plant == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Plant = "Not found" });

                plant.Name = request.Name ?? plant.Name;
                plant.Comment = request.Comment ?? plant.Comment;
                plant.GardenId = request.GardenId;
                plant.StrainId = request.StrainId;
                plant.Notes = request.Notes ?? plant.Notes;
                plant.GrowCycleLength = request.GrowCycleLength ?? plant.GrowCycleLength;
                plant.Aquired = request.Aquired;
                plant.Parentage = request.Parentage ?? plant.Parentage;
                plant.Origin = request.Origin ?? plant.Origin;
                plant.Gender = request.Gender ?? plant.Gender;
                plant.DaysFlowering = request.DaysFlowering;
                plant.DaysCured = request.DaysCured;
                plant.HarvestedWeight = request.HarvestedWeight ?? plant.HarvestedWeight;
                plant.BudDensity = request.BudDensity;
                plant.BudPistils = request.BudPistils;
                plant.Tags = request.Tags ?? plant.Tags;
                plant.Editors = request.Editors ?? plant.Editors;
                plant.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}