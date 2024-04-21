using Microsoft.EntityFrameworkCore;
using StarisApi.Models.CharacterMovies;
using StarisApi.Models.Characters;
using StarisApi.Models.Movies;
using StarisApi.Models.Planets;
using StarisApi.Models.StarShips;
using StarisApi.Models.Vehicles;

namespace StarisApi.DbContexts
{
    public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Planet> Planets { get; set; } = null!;
        public DbSet<StarShip> StarShips { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<CharacterMovie> CharacterMovies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterDbMap());
            modelBuilder.ApplyConfiguration(new MovieDbMap());
            modelBuilder.ApplyConfiguration(new PlanetDbMap());
            modelBuilder.ApplyConfiguration(new StarShipDbMap());
            modelBuilder.ApplyConfiguration(new VehicleDbMap());
            modelBuilder.ApplyConfiguration(new CharacterMovieDbMap());
        }
    }
}
