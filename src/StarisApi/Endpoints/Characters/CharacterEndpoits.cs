using Microsoft.EntityFrameworkCore;
using StarisApi.DbContexts;
using StarisApi.Models.Characters;
using StarisApi.Requests;

namespace StarisApi.Endpoints.Characters
{
    public static class CharacterEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {
            
            app.MapGet("/character", ([AsParameters] Request request, SqliteContext context) => 
            {
                var characters = context.Characters
                .Include(c => c.Planet)
                .Select(c => new Character
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthYear = c.BirthYear,
                    EyeColor = c.EyeColor,
                    Gender = c.Gender,
                    HairColor = c.HairColor,
                    Height = c.Height,
                    Mass = c.Mass,
                    SkinColor = c.SkinColor,
                    PlanetId = c.PlanetId,
                    Planet = new Models.Planets.Planet
                    {
                        Id = c.Planet.Id,
                        Climate = c.Planet.Climate,
                        Diameter = c.Planet.Diameter,
                        Gravity = c.Planet.Gravity,
                        Name = c.Planet.Name,
                        OrbitalPeriod = c.Planet.OrbitalPeriod,
                        Population = c.Planet.Population,
                        RotationSpeed = c.Planet.RotationSpeed,
                        SurfaceWater = c.Planet.SurfaceWater,
                        Terrain = c.Planet.Terrain,
                    }
                    
                })
                .ToList();
                return Results.Ok(characters);
            }).WithTags("Character")
              .WithOpenApi();

            return app;
        }
    }


}
