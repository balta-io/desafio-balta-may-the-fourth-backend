using StarisApi.DbContexts;
using StarisApi.Requests;

namespace StarisApi.Endpoints.Characters
{
    public static class CharacterEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {
            
            app.MapGet("/character", ([AsParameters] Request request, SqliteContext context) => 
            {
                var chracters = context.Characters.ToList();
                return Results.Ok(chracters);
            }).WithTags("Character")
              .WithOpenApi();

            return app;
        }
    }


}
