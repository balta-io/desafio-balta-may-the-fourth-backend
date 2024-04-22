using Microsoft.EntityFrameworkCore;
using StarisApi.Models.PeopleFilms;
using StarisApi.Models.PeoplePlanets;
using StarisApi.Models.People;
using StarisApi.Models.FilmsPlanet;
using StarisApi.Models.Films;
using StarisApi.Models.MovieStarship;
using StarisApi.Models.FilmsVehicle;
using StarisApi.Models.Planets;
using StarisApi.Models.StarShips;
using StarisApi.Models.Vehicles;
using StarisApi.Models.FilmsStarship;
using StarisApi.Models.Starships;

namespace StarisApi.DbContexts
{
    public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<Planet> Planets { get; set; } = null!;
        public DbSet<Starship> StarShips { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<PersonFilm> PeopleMovies { get; set; } = null!;
        public DbSet<PersonPlanet> PeoplePlanets { get; set; } = null!;
        public DbSet<FilmPlanet> FilmsPlanets { get; set; } = null!;
        public DbSet<FilmStarship> FilmsStarships { get; set; } = null!;
        public DbSet<FilmVehicle> FilmsVehicles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonDbMap());
            modelBuilder.ApplyConfiguration(new FilmDbMap());
            modelBuilder.ApplyConfiguration(new PlanetDbMap());
            modelBuilder.ApplyConfiguration(new StarshipDbMap());
            modelBuilder.ApplyConfiguration(new VehicleDbMap());
            modelBuilder.ApplyConfiguration(new PersonFilmDbMap());
            modelBuilder.ApplyConfiguration(new PersonPlanetDbMap());
            modelBuilder.ApplyConfiguration(new FilmPlanetDbMap());
            modelBuilder.ApplyConfiguration(new FilmStarshipDbMap());
            modelBuilder.ApplyConfiguration(new FilmVehicleDbMap());
        }
    }
}
