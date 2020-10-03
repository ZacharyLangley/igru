using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenEntry> GardenEntries { get; set; }
        public DbSet<Plant> Plants {get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
