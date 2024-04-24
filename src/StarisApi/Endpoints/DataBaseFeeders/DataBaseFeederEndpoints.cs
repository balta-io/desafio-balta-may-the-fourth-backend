using StarisApi.DbContexts;
using StarisApi.Dtos;
using StarisApi.Extensions;
using StarisApi.Models;
using StarisApi.Models.Characters;
using StarisApi.Repository;

namespace StarisApi.Endpoints.DataBaseFeeders;

public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/seed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            var infosMovies = await feeder.GetInfoFromMoviesEndpoint();
            var infosCharacters = await feeder.GetInfoFromPeopleEndpoint();
            var infoPlanets = await feeder.GetInfoFromPlanetsEndpoint();
            var infoStarShips = await feeder.GetInfoFromStarshiptEndpoint();
            var infoVehicles = await feeder.GetInfoFromVehicleEndpoint();

            var filmsBase = feeder.GetMoviesBase(infosMovies);
            var charactersBase = feeder.GetCharactersBase(infosCharacters);
            var planetsBase = feeder.GetPlanetsBase(infoPlanets);
            var starshipsBase = feeder.GetStarshipsBase(infoStarShips);
            var vehiclesBase = feeder.GetVehiclesBase(infoVehicles);

            //context.Movies.AddRange(filmsBase);
            //context.Characters.AddRange(charactersBase);
            //context.Planets.AddRange(planetsBase);
            //context.StarShips.AddRange(starshipsBase);
            //context.Vehicles.AddRange(vehiclesBase);

            var relationCharacterMovie = feeder.GetCharacterMovieRelation(filmsBase, charactersBase);
            var relationMoviePlanet = feeder.GetMoviePlanetRelation(filmsBase, planetsBase);
            var relationMovieVehicle = feeder.GetMovieVehicleRelation(filmsBase, vehiclesBase);
            var relationMovieStarship = feeder.GetMovieStarshipRelation(filmsBase, starshipsBase);

            //context.CharacterMovies.AddRange(relationCharacterMovie);
            //context.MoviesPlanets.AddRange(relationMoviePlanet);
            //context.MoviesStarships.AddRange(relationMovieStarship);
            //context.MoviesVehicles.AddRange(relationMovieVehicle);

            //var movies = feeder.GetMovies(filmsBase, relationMovieVehicle, relationMoviePlanet, relationMovieStarship, relationCharacterMovie);
            //var characters = feeder.GetCharacters(charactersBase, relationCharacterMovie);

            //await context.SaveChangesAsync();

            return infosMovies.Count != 0 ? TypedResults.Ok("TEST") : Results.NoContent();
        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/CharacterImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            var characterNames = context.Characters.ToDictionary(character => character.Id, character => character.Name);
            var imagesUrlRelations = await feeder.ScrappyUrlImage(characterNames);
            var characters = context.Characters.ToList();

            characters.ForEach(character => {
                if(imagesUrlRelations.TryGetValue(character.Id, out string? link))
                {
                    character.ImageUrl = link ?? string.Empty;
                }
            });

            context.Characters.UpdateRange(characters);
            await context.SaveChangesAsync();

            return TypedResults.Ok("Characters Image URL feed with success.");

        }).WithTags("Seed")
          .WithOpenApi();

        return app;
    }
}
