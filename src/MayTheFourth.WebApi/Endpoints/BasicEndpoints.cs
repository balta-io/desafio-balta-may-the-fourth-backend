using MayTheFourth.Application.Features.BasicExample;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class BasicEndpoints
    {
        public static void MapBasicEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/basic")
                .WithTags("Basic")
                .WithOpenApi();

            root.MapPost("/", AddProductAsync)
                .WithSummary("Add a new product")
                .WithDescription("Create a new product");

            root.MapGet("/", () => "HelloWorld!")
                .WithSummary("Get a new product")
                .WithDescription("Get a new product");

            root.MapPut("/", () => "HelloWorld!")
                .WithSummary("Update a product")
                .WithDescription("Update a product");

            root.MapDelete("/{id}", () => "HelloWorld!")
                .WithSummary("Delete a product")
                .WithDescription("Delete a product");
        }

        public static async Task<IActionResult> AddProductAsync
        (
            AddProductRequest request,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken = default
        )
        {
            var result = await mediator.Send(request, cancellationToken);

            return new ObjectResult(result)
            {
                StatusCode = 201
            };
        }
    }
}
