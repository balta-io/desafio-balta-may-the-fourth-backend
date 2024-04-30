using StarisApi.Models;
using StarisApi.Models.Movies;
using StarisApi.Repository;

namespace StarisApi.Endpoints;
public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits<TEntity>(this IEndpointRouteBuilder app)
        where TEntity : Entity, new()
    {
        var endpoint = $"{typeof(TEntity).ToString().Split(".").Last().Replace("TEntity", string.Empty)}s";
        var tag = endpoint[..^1];
        app.MapPost($"/seed{endpoint}", async (DataBaseFeederRepository<TEntity> contextFeeder) =>
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
        app.MapPost("/seedRelations", async (DataBaseFeederRepository<Movie> contextFeeder) =>
        {
            var infos = await contextFeeder.GetInfoFromEndpoint("Movie");
            await contextFeeder.FeedRelationsTable(infos);
        }).WithTags("Relation")
          .WithOpenApi();
        return app;
    }
}
