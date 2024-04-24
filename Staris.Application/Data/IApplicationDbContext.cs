using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;

namespace Staris.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Character> Characters { get; set; }
    DbSet<CharacterFilm> CharacterFilms { get; set; }
    DbSet<CharacterPlanet> CharacterPlanets { get; set; }
    DbSet<Film> Films { get; set; }
    DbSet<Planet> Planets { get; set; }
    DbSet<PlanetFilm> PlanetFilms { get; set; }
    DbSet<Starship> Starships { get; set; }
    DbSet<StarshipFilm> StarshipFilms { get; set; }
    DbSet<Vehicle> Vehicles { get; set; }
    DbSet<VehicleFilm> VehicleFilms { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);



    

}
