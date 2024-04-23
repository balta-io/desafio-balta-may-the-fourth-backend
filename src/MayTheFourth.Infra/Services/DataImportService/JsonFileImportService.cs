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
                                    List<PersonDTO> people = JsonSerializer.Deserialize<List<PersonDTO>>(results.GetRawText())!;

                                    foreach(var personDTO in people)
                                    {
                                        await _appDbContext.People.AddAsync(personDTO.ToPerson());
                                    }
                                    //await _appDbContext.SaveChangesAsync();
                                    break;

                                case "planets":
                                    List<PlanetDTO> planets = JsonSerializer.Deserialize<List<PlanetDTO>>(results.GetRawText())!;

                                    foreach (var planetDTO in planets)
                                    {
                                        await _appDbContext.Planets.AddAsync(planetDTO.ToPlanet());
                                        //var planet = planetDTO.ToPlanet();
                                        //string query = @$"INSERT INTO [dbo].[Planets]
                                        //           ([Id]
                                        //           ,[Name]
                                        //           ,[Diameter]
                                        //           ,[RotationPeriod]
                                        //           ,[OrbitalPeriod]
                                        //           ,[Gravity]
                                        //           ,[Population]
                                        //           ,[Climate]
                                        //           ,[Terrain]
                                        //           ,[SurfaceWater]
                                        //           ,[Url]
                                        //           ,[Created]
                                        //           ,[Edited])
                                        //     VALUES
                                        //           ('{planet.Id}',
                                        //           '{planet.Name}',
                                        //           {planet.Diameter},
                                        //           {planet.RotationPeriod},
                                        //           {planet.OrbitalPeriod},
                                        //           '{planet.Gravity}',
                                        //           {planet.Population},
                                        //           '{planet.Climate}',
                                        //           '{planet.Terrain}',
                                        //           '{planet.SurfaceWater}',
                                        //           '{planet.Url}',
                                        //           '{planet.Created}',
                                        //           '{planet.Edited}')";
                                        //_appDbContext.Database.ExecuteSqlRaw(query);
                                    }
                                    await _appDbContext.SaveChangesAsync();
                                    break;
                            }
                        }

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
