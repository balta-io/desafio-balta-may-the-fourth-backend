using StarisApi.DbContexts;
using StarisApi.Models.CharactersMovies;
using StarisApi.Repository;

namespace StarisApi.Endpoints.DataBaseFeeders;
//teste
public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapPost("/seed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var infosMovies = await feeder.GetInfoFromMoviesEndpoint();
                var infosCharacters = await feeder.GetInfoFromPeopleEndpoint();
                var infoPlanets = await feeder.GetInfoFromPlanetsEndpoint();
                var infoStarShips = await feeder.GetInfoFromStarshiptEndpoint();
                var infoVehicles = await feeder.GetInfoFromVehicleEndpoint();

                var filmsBase = feeder.GetMoviesBase(infosMovies);
                var charactersBase = await feeder.GetCharactersBase(infosCharacters);
                var planetsBase = feeder.GetPlanetsBase(infoPlanets);
                var starshipsBase = feeder.GetStarshipsBase(infoStarShips);
                var vehiclesBase = feeder.GetVehiclesBase(infoVehicles);

                context.Movies.AddRange(filmsBase);
                context.Characters.AddRange(charactersBase);
                context.Planets.AddRange(planetsBase);
                context.StarShips.AddRange(starshipsBase);
                context.Vehicles.AddRange(vehiclesBase);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Results.NoContent();
            }

            return TypedResults.Ok("Database successfully feed.");
        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/RelationsSeed", async (SqliteContext context, DataBaseFeeder feeder) => {
            var movies = context.Movies.ToList();
            var characterMovie = movies.SelectMany(x => x.Characters).ToList();
            var moviePlanet = movies.SelectMany(x => x.Planets).ToList();
            var movieStarship = movies.SelectMany(x => x.Starships).ToList();
            var movieVehicle = movies.SelectMany(x => x.Vehicles).ToList();

            context.CharacterMovies.AddRange(characterMovie);
            context.MoviesPlanets.AddRange(moviePlanet);
            context.MoviesStarships.AddRange(movieStarship);
            context.MoviesVehicles.AddRange(movieVehicle);
            await context.SaveChangesAsync();
        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/CharacterSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var infosCharacters = await feeder.GetInfoFromPeopleEndpoint();
                var charactersBase = await feeder.GetCharactersBase(infosCharacters);

                context.Characters.AddRange(charactersBase);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.BadRequest();
            }

            return TypedResults.Ok("Characters table feed with success.");

        }).WithTags("Seed")
          .WithOpenApi();

        //TODO: daqui para baixo, remover.
        app.MapPost("/PlanetImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var planets = context.Planets.ToList();
                //var planetIdNames = planets.ToDictionary(planet => planet.Id, planet => planet.Name);
                //var imagesUrlRelations = await feeder.ScrappyUrlImage(planetIdNames);

                //planets.ForEach(planet => {
                //    if (imagesUrlRelations.TryGetValue(planet.Id, out string? link))
                //    {
                //        planet.ImageUrl = link ?? string.Empty;
                //    }
                //});

                context.Planets.UpdateRange(planets);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.BadRequest();
            }

            return TypedResults.Ok("Planets Image URL feed with success.");

        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/StarshipImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var starShips = context.StarShips.ToList();
                //var starShipIdNames = starShips.ToDictionary(starShip => starShip.Id, starShip => starShip.Name);
                //var imagesUrlRelations = await feeder.ScrappyUrlImage(starShipIdNames);

                //starShips.ForEach(starShip => {
                //    if (imagesUrlRelations.TryGetValue(starShip.Id, out string? link))
                //    {
                //        starShip.ImageUrl = link ?? string.Empty;
                //    }
                //});

                context.StarShips.UpdateRange(starShips);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.BadRequest();
            }

            return TypedResults.Ok("StarShips Image URL feed with success.");

        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/VehicleImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var vehicles = context.Vehicles.ToList();
                //var vehicleNames = vehicles.ToDictionary(vehicle => vehicle.Id, vehicle => vehicle.Name);
                //var imagesUrlRelations = await feeder.ScrappyUrlImage(vehicleNames);

                //vehicles.ForEach(vehicle => {
                //    if (imagesUrlRelations.TryGetValue(vehicle.Id, out string? link))
                //    {
                //        vehicle.ImageUrl = link ?? string.Empty;
                //    }
                //});

                context.Vehicles.UpdateRange(vehicles);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.BadRequest();
            }

            return TypedResults.Ok("Vehicles Image URL feed with success.");

        }).WithTags("Seed")
          .WithOpenApi();

        app.MapPost("/MovieImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        {
            try
            {
                var movies = context.Movies.ToList();
                var imagesUrlRelations = feeder.ScrappyUrlImageForMovies(movies);

                context.Movies.UpdateRange(movies);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.BadRequest();
            }

            return TypedResults.Ok("Movies Image URL feed with success.");

        }).WithTags("Seed")
  .WithOpenApi();

        return app;
    }
}
