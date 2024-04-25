using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;

namespace Staris.Application.Data;

public interface IApplicationDbContext
{
	DbSet<Character> Characters { get; set; }
	DbSet<CharacterFilm> CharacterFilms { get; set; }
	DbSet<PlanetCharacter> PlanetCharacters { get; set; }
	DbSet<Film> Films { get; set; }
	DbSet<Planet> Planets { get; set; }
	DbSet<PlanetFilm> PlanetFilms { get; set; }
	DbSet<Starship> Starships { get; set; }
	DbSet<Vehicle> Vehicles { get; set; }
	DbSet<FilmVehicle> FilmVehicles { get; set; }


	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);



    

}
