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

namespace Application.NutrientRecipes
{
    public class Edit
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
                var nutrientRecipe = await _context.NutrientRecipes.FindAsync(request.Id);

                if (nutrientRecipe == null)
                    throw new RestException(HttpStatusCode.NotFound, new { NutrientRecipe = "Not found" });

                nutrientRecipe.Name = request.Name ?? nutrientRecipe.Name;
                nutrientRecipe.Comment = request.Comment ?? nutrientRecipe.Comment;
                nutrientRecipe.Instructions = request.Instructions ?? nutrientRecipe.Instructions;
                nutrientRecipe.PH = request.PH ?? nutrientRecipe.PH;
                nutrientRecipe.MixTime = request.MixTime ?? nutrientRecipe.MixTime;
                nutrientRecipe.Tags = request.Tags ?? nutrientRecipe.Tags;
                nutrientRecipe.Editors = request.Editors ?? nutrientRecipe.Editors;
                nutrientRecipe.LastUpdated = DateTime.Now;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}