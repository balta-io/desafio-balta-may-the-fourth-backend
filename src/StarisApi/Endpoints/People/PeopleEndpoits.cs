
using Microsoft.AspNetCore.Mvc;
using StarisApi.Dtos;
using StarisApi.Models.People;
using StarisApi.Repository;
using StarisApi.Requests;

namespace StarisApi.Endpoints.Characters
{
    public static class PeopleEndpoits
    {
        public static IEndpointRouteBuilder MapCharacterEndpoits(this IEndpointRouteBuilder app)
        {

            app.MapGet("/people", ([AsParameters] Request request, Repository<Person> context) =>
            {
                var characters = context.GetAll<PersonDto>(request);
                return characters.Results.Any() ? TypedResults.Ok(characters) : Results.NoContent();

            }).WithTags("Character")
              .Produces(TypedResults.Ok().StatusCode)
              .Produces(TypedResults.NoContent().StatusCode)
              .WithOpenApi();

            app.MapGet("/people/{id}", ([FromRoute] int id, Repository<Person> context) =>
            {
                var character = context.Find(id);

                return character is null ? Results.NotFound() : TypedResults.Ok(character);
                
            }).WithTags("Character")
              .WithOpenApi();

            return app;
        }
    }


}
