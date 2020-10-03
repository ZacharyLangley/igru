using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Plants
{
    public class Create
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
            var plant = new Plant
            {
                Name = request.Name,
                Comment = request.Comment,
                Notes = request.Notes,
                GardenId = request.GardenId,
                StrainId = request.StrainId,
                GrowCycleLength = request.GrowCycleLength,
                Aquired = request.Aquired,
                Parentage = request.Parentage,
                Origin = request.Origin,
                Gender = request.Gender,
                DaysFlowering = request.DaysFlowering,
                DaysCured = request.DaysCured,
                HarvestedWeight = request.HarvestedWeight,
                BudDensity = request.BudDensity,
                BudPistils = request.BudPistils,
                Tags = request.Tags,
                Editors = request.Editors,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            _context.Plants.Add(plant);
            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
    }
}