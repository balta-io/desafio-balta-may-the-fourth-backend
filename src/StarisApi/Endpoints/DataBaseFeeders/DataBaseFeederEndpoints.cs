using StarisApi.DbContexts;
using StarisApi.Repository;

namespace StarisApi.Endpoints.DataBaseFeeders;

public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/dbFeeder", async (SqliteContext context, DataBaseFeeder feeder) =>
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

            context.CharacterMovies.AddRange(relationCharacterMovie);
            context.MoviesPlanets.AddRange(relationMoviePlanet);
            context.MoviesStarships.AddRange(relationMovieStarship);
            context.MoviesVehicles.AddRange(relationMovieVehicle);

            //var movies = feeder.GetMovies(filmsBase, relationMovieVehicle, relationMoviePlanet, relationMovieStarship, relationCharacterMovie);
            //var characters = feeder.GetCharacters(charactersBase, relationCharacterMovie);

            await context.SaveChangesAsync();

            return relationCharacterMovie.Count != 0 ? TypedResults.Ok(relationCharacterMovie) : Results.NoContent();
        });

        return app;
    }
}
