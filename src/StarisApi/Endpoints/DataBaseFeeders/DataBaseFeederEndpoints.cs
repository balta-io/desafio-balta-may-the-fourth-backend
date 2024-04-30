using StarisApi.DbContexts;
using StarisApi.Models;
using StarisApi.Repository;

namespace StarisApi.Endpoints.DataBaseFeeders;
public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits<TEntity>(this IEndpointRouteBuilder app)
        where TEntity : Entity, new()
    {
        var endpoint = $"{typeof(TEntity).ToString().Split(".").Last().Replace("TEntity", string.Empty)}s";
        var tag = endpoint[..^1];
        app.MapPost($"/seed{endpoint}", async (DataBaseFeeder<TEntity> contextFeeder) =>
        {
            try
            {
                var infos = await contextFeeder.GetInfoFromEndpoint(tag);
                var entityBase = await contextFeeder.GetEntityBase<TEntity>(infos);
                await contextFeeder.InsertNew<TEntity>(entityBase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Results.NoContent();
            }

            return TypedResults.Ok("Database successfully feed.");
        }).WithTags(tag)
          .WithOpenApi();
        return app;
    }

    public static IEndpointRouteBuilder MapDataRelationFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapPost("/seedRelations", async(SqliteContext context) => {
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
        }).WithTags("Relation")
          .WithOpenApi();
        return app;
    }
}
