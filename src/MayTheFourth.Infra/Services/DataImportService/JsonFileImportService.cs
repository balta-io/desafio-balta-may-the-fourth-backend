using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using MayTheFourth.Infra.DTOs;
using MayTheFourth.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
                        await _appDbContext.SaveChangesAsync();
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
