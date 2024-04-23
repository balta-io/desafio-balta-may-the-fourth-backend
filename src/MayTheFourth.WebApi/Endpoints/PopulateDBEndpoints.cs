using MayTheFourth.Application.Features.PopulateDataBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class PopulateDBEndpoints
    {
        public static void MapPopulateDBEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/populatedb")
                .WithTags("PopulateDB")
                .WithOpenApi();

            root.MapPost("/", PopulateDBAsync)
                .Produces(StatusCodes.Status204NoContent)
                .WithSummary("Popula base de dados")
                .WithDescription("Endpoint para popular base de dados de acordo com a Api do Star Wars");
        }

        private static async Task<IResult> PopulateDBAsync
        (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            await mediator.Send(new PopulateDBRequest(), cancellationToken);

            return Results.NoContent();
        }
    }
}
