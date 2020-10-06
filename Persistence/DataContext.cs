using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
            public DbSet<Garden> Gardens { get; set; }
            public DbSet<GardenEntry> GardenEntries { get; set; }
            public DbSet<Plant> Plants { get; set; }
            public DbSet<PlantEntry> PlantEntries { get; set; }
            public DbSet<Strain> Strains { get; set; }
            public DbSet<NutrientRecipe> NutrientRecipes { get; set; }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }
    }
}
