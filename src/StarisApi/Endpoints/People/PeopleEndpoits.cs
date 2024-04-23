
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarisApi.DbContexts;
using StarisApi.Dtos;
using StarisApi.Extensions;
using StarisApi.Models.Characters;
using StarisApi.Repository;
using StarisApi.Requests;

namespace StarisApi.Endpoints.Characters
{
    public static class CharactersEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {

            app.MapGet("/characters", ([AsParameters] Request request, Repository<Character> context) =>
            {
                var characters = context.GetAll<CharacterDto>(request);
                return characters.Results.Any() ? TypedResults.Ok(characters) : Results.NoContent();

            }).WithTags("Character")
              .Produces(TypedResults.Ok().StatusCode)
              .Produces(TypedResults.NoContent().StatusCode)
              .WithOpenApi();

            app.MapGet("/characters/{id}", ([FromRoute] int id, Repository<Character> context) =>
            {
                var character = context.Find(id);

                return character is null ? Results.NotFound() : TypedResults.Ok(character);
                
            }).WithTags("Character")
              .WithOpenApi();

            return app;
        }
    }


}
