namespace StarisApi.Endpoints.Characters
{
    public static class CharacterEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {
            app.MapGet("/character", () => "Darth Vader").WithTags("Character").WithOpenApi();

            return app;
        }
    }
}
