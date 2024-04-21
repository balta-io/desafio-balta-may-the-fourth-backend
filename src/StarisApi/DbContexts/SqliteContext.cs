using Microsoft.EntityFrameworkCore;
using StarisApi.Models.CharacterMovies;
using StarisApi.Models.CharacterPlanets;
using StarisApi.Models.Characters;
using StarisApi.Models.MoviePlanet;
using StarisApi.Models.Movies;
using StarisApi.Models.MovieStarship;
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
        public DbSet<CharacterPlanet> CharacterPlanets { get; set; } = null!;
        public DbSet<MoviePlanet> MoviePlanets { get; set; } = null!;
        public DbSet<MovieStarship> MovieStarships { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterDbMap());
            modelBuilder.ApplyConfiguration(new MovieDbMap());
            modelBuilder.ApplyConfiguration(new PlanetDbMap());
            modelBuilder.ApplyConfiguration(new StarShipDbMap());
            modelBuilder.ApplyConfiguration(new VehicleDbMap());
            modelBuilder.ApplyConfiguration(new CharacterMovieDbMap());
            modelBuilder.ApplyConfiguration(new CharacterPlanetDbMap());
            modelBuilder.ApplyConfiguration(new MoviePlanetDbMap());
            modelBuilder.ApplyConfiguration(new MovieStarshipDbMap());
        }
    }
}
