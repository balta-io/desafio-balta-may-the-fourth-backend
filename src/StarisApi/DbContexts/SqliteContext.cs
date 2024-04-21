using Microsoft.EntityFrameworkCore;
using StarisApi.Models.Characters;
using StarisApi.Models.Movies;
using StarisApi.Models.Planets;

namespace StarisApi.DbContexts
{
    public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Planet> Planets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterDbMap());
            modelBuilder.ApplyConfiguration(new MovieDbMap());
            modelBuilder.ApplyConfiguration(new PlanetDbMap());
        }
    }
}
