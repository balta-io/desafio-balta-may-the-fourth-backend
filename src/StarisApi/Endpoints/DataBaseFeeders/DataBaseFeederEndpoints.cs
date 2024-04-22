using StarisApi.DbContexts;
using StarisApi.Repository;
using System.Text.Json;

namespace StarisApi.Endpoints.DataBaseFeeders;

public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/dbFeederCharacter", async (SqliteContext context, DataBaseFeeder feeder) => {
            var infos = await GetAll(feeder);
        });

        return app;
    }

    private static async Task<IEnumerable<JsonElement>> GetAll(DataBaseFeeder feeder)
    {
        var list = new List<JsonElement>();
        for(var i = 0; i < 8; i++)
        {
            list.AddRange(await feeder.GetInfoFromPeopleEndpoint(i));
        }

        return list;
    }
}
