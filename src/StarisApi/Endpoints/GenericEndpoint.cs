using Microsoft.AspNetCore.Mvc;
using StarisApi.Dtos;
using StarisApi.Models;
using StarisApi.Models.Characters;
using StarisApi.Repository;
using StarisApi.Requests;

namespace StarisApi.Endpoints
{
    public static class GenericEndpoint
    {
        public static IEndpointRouteBuilder MapGenericEndpoint<TEntity, TDto>(this IEndpointRouteBuilder app) 
            where TEntity : Entity, new() where TDto : class, IDto
        {
            var endpoint = $"{typeof(TDto).ToString().Split(".").Last().Replace("Dto", string.Empty).ToLower()}s";
            var tag = typeof(TDto).ToString().Split(".").Last().Replace("Dto", string.Empty);

            app.MapGet($"/{endpoint}", ([AsParameters] Request request, Repository<TEntity> context) =>
            {
                var lista = context.GetAll<TDto>(request);
                return lista.Results.Any() ? TypedResults.Ok(lista) : Results.NoContent();

            }).WithTags(tag)
              .Produces(TypedResults.Ok().StatusCode)
              .Produces(TypedResults.NoContent().StatusCode)
              .WithOpenApi();

            app.MapGet(endpoint + "/{id}", ([FromRoute] int id, Repository<TEntity> context) =>
            {
                var result = context.Find(id);

                return result is null ? Results.NotFound() : TypedResults.Ok(result);
                
            }).WithTags(tag)
              .WithOpenApi();

            return app;
        }   
    }
}
