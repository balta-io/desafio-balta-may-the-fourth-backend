using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using MayTheFourth.Infra.DTOs;
using MayTheFourth.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Services.DataImportService
{
    public class JsonFileImportService : IDataImportService
    {
        private readonly AppDbContext _appDbContext;

        public string FileName { get; set; } = string.Empty;

        public JsonFileImportService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private bool IsDatabaseEmpty()
        {
            return !_appDbContext.Planets.Any()
                    && !_appDbContext.Starships.Any()
                    && !_appDbContext.Films.Any()
                    && !_appDbContext.People.Any()
                    && !_appDbContext.Species.Any();
        }

        public async Task ImportDataAsync()
        {
            List<PersonDTO> people = new();
            List<PlanetDTO> planets = new();
            List<FilmDTO> films = new();
            List<SpeciesDTO> speciesList = new();
            List<StarshipDTO> starships = new();
            List<VehicleDTO> vehicles = new();

            if (!IsDatabaseEmpty()) return;
            try
            {
                using (var stream = File.OpenRead(FileName))
                {
                    using (JsonDocument doc = await JsonDocument.ParseAsync(stream))
                    {
                        JsonElement root = doc.RootElement;
                        foreach (JsonElement element in root.EnumerateArray())
                        {
                            var endpoint = element.GetProperty("Endpoint").GetString();
                            JsonElement data = element.GetProperty("Data");
                            JsonElement results = data.GetProperty("results");
                            switch (endpoint)
                            {
                                case "people":
                                    people = JsonSerializer.Deserialize<List<PersonDTO>>(results.GetRawText())!;
                                    break;

                                case "planets":
                                    planets = JsonSerializer.Deserialize<List<PlanetDTO>>(results.GetRawText())!;
                                    break;

                                case "films":
                                    films = JsonSerializer.Deserialize<List<FilmDTO>> (results.GetRawText())!;
                                    break;

                                case "species":
                                    speciesList = JsonSerializer.Deserialize<List<SpeciesDTO>>(results.GetRawText())!;
                                    break;

                                case "starships":
                                    starships = JsonSerializer.Deserialize<List<StarshipDTO>>(results.GetRawText())!;
                                    break;

                                case "vehicles":
                                    vehicles = JsonSerializer.Deserialize<List<VehicleDTO>>(results.GetRawText())!;
                                    break;
                            }
                        }
                    }

                    // Cadastrar os planets primeiro
                    foreach (var planetDTO in planets)
                    {
                        await _appDbContext.Planets.AddAsync(planetDTO.ToPlanet());
                    }
                    await _appDbContext.SaveChangesAsync();

                    // Depois people
                    foreach (var personDTO in people)
                    {
                        // Encontrar homeworld (planet) pela url
                        var planet = _appDbContext.Planets.FirstOrDefault(p => p.Url.Equals(personDTO.Homeworld));
                        var person = personDTO.ToPerson();
                        person.HomeworldId = planet!.Id;
                        await _appDbContext.People.AddAsync(person);
                    }
                    await _appDbContext.SaveChangesAsync();

                    // films
                    foreach (var filmDTO in films)
                    {
                        await _appDbContext.Films.AddAsync(filmDTO.ToFilm());
                    }
                    await _appDbContext.SaveChangesAsync();

                    // species
                    foreach (var speciesDTO in speciesList)
                    {
                        // Encontrar homeworld (planet) pela url
                        var species = speciesDTO.ToSpecies();
                        if (!speciesDTO.Homeworld.IsNullOrEmpty())
                        {
                            var planet = _appDbContext.Planets.FirstOrDefault(p => p.Url.Equals(speciesDTO.Homeworld));
                            species.HomeworldId = planet!.Id;
                        }
                        await _appDbContext.Species.AddAsync(species);
                    }
                    await _appDbContext.SaveChangesAsync();

                    // starships
                    foreach (var starshipDTO in starships)
                    {
                        await _appDbContext.Starships.AddAsync(starshipDTO.ToStarship());
                    }
                    await _appDbContext.SaveChangesAsync();


                    // vehicles
                    foreach (var vehicleDTO in vehicles)
                    {
                        await _appDbContext.Vehicles.AddAsync(vehicleDTO.ToVehicle());
                    }
                    await _appDbContext.SaveChangesAsync();

                    #region relacionamentos
                    // planet
                    foreach (var planetDTO in planets)
                    {
                        var planet = await _appDbContext.Planets.FirstOrDefaultAsync( p => p.Url.Equals(planetDTO.Url));
                        //foreach(var url in planetDTO.Residents!)
                        //{
                        //    var person = await _appDbContext.People.FirstOrDefaultAsync(p => p.Url.Equals(url));
                        //    planet!.Residents.Add(person!);
                        //}

                        foreach (var url in planetDTO.Films!)
                        {
                            var film = await _appDbContext.Films.FirstOrDefaultAsync(f => f.Url.Equals(url));
                            planet!.Films.Add(film!);
                        }
                        _appDbContext.Planets.Update(planet!);
                    }
                    await _appDbContext.SaveChangesAsync();

                    //person
                    foreach (var personDTO in people)
                    {
                        var person = await _appDbContext.People.FirstOrDefaultAsync(p => p.Url.Equals(personDTO.Url));
                        foreach (var url in personDTO.Films)
                        {
                            var film = await _appDbContext.Films.FirstOrDefaultAsync(f => f.Url.Equals(url));
                            person!.Films.Add(film!);
                        }

                        foreach (var url in personDTO.Species!)
                        {
                            var specie = await _appDbContext.Species.FirstOrDefaultAsync(s => s.Url.Equals(url));
                            person!.Species.Add(specie!);
                        }

                        foreach (var url in personDTO.Starships!)
                        {
                            var starship = await _appDbContext.Starships.FirstOrDefaultAsync(s => s.Url.Equals(url));
                            person!.Starships.Add(starship!);
                        }

                        foreach (var url in personDTO.Vehicles!)
                        {
                            var vehicle = await _appDbContext.Vehicles.FirstOrDefaultAsync(v => v.Url.Equals(url));
                            person!.Vehicles.Add(vehicle!);
                        }

                        _appDbContext.People.Update(person!);
                    }
                    await _appDbContext.SaveChangesAsync();

                    //person
                    foreach (var filmDTO in films)
                    {
                        var film = await _appDbContext.Films.FirstOrDefaultAsync(f => f.Url.Equals(filmDTO.Url));
                        foreach (var url in filmDTO.SpeciesList)
                        {
                            var specie = await _appDbContext.Species.FirstOrDefaultAsync(s => s.Url.Equals(url));
                            film!.SpeciesList.Add(specie!);
                        }

                        foreach (var url in filmDTO.Starships)
                        {
                            var starship = await _appDbContext.Starships.FirstOrDefaultAsync(s => s.Url.Equals(url));
                            film!.Starships.Add(starship!);
                        }

                        foreach (var url in filmDTO.Vehicles)
                        {
                            var vehicle = await _appDbContext.Vehicles.FirstOrDefaultAsync(v => v.Url.Equals(url));
                            film!.Vehicles.Add(vehicle!);
                        }
                        _appDbContext.Films.Update(film!);
                    }
                    await _appDbContext.SaveChangesAsync();

                    #endregion
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
