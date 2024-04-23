using MayTheFourth.Entities;
using MayTheFourth.Repositories.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace MayTheFourth.Repositories.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options)
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(new Map_Vehicle().Configure);
            modelBuilder.Entity<Movie>(new Map_Movie().Configure);
            modelBuilder.Entity<Character>(new Map_Character().Configure);
            modelBuilder.Entity<Planet>(new Map_Planet().Configure);
            modelBuilder.Entity<Starship>(new Map_Starship().Configure);
        }

        internal class SequenceValueGenerator : ValueGenerator<Guid>
        {
            public override bool GeneratesTemporaryValues => false;

            public override Guid Next(EntityEntry entry)
            {
                return Guid.NewGuid();
            }
        }
    }
}
