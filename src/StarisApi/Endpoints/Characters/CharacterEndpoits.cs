using Microsoft.AspNetCore.Mvc;
using StarisApi.DbContexts;
using StarisApi.Dtos;
using StarisApi.Models.Characters;
using StarisApi.Repository;
using StarisApi.Requests;
using StarisApi.Responses;

namespace StarisApi.Endpoints.Characters
{
    public static class CharacterEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {

            app.MapGet("/character", ([AsParameters] Request request, Repository<Character> context) =>
            {
                var characters = context.GetAll<CharacterDto>(request);
                return characters.Results.Any() ? TypedResults.Ok(characters) : Results.NoContent();

            }).WithTags("Character")
              .Produces(TypedResults.Ok().StatusCode)
              .Produces(TypedResults.NoContent().StatusCode)
              .WithOpenApi();

            app.MapGet("/character/{id}", ([FromRoute] int id, Repository<Character> context) =>
            {
                var character = context.Find(id);

                return character is null ? Results.NotFound() : TypedResults.Ok(character);

            }).WithTags("Character")
              .WithOpenApi();

            return app;
        }
    }


}
