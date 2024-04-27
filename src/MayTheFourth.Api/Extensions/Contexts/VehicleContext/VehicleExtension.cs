using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Api.Extensions.Contexts.VehicleContext;

public static class VehicleExtension
{
    public static void AddVehicleContext(this WebApplicationBuilder builder)
    {
        #region Register Vehicle Repository
        builder.Services.AddTransient
            <Core.Interfaces.Repositories.IVehicleRepository,
            Infra.Repositories.VehicleRepository>();
        #endregion
    }

    public static void MapVehicleEndpoints(this WebApplication app)
    {
        #region Get all vehicles
        app.MapGet("api/v1/vehicles", async
            (IRequestHandler<Core.Contexts.VehicleContext.UseCases.SearchAll.Request,
                Core.Contexts.VehicleContext.UseCases.SearchAll.Response> handler) =>
        {
            var request = new Core.Contexts.VehicleContext.UseCases.SearchAll.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Vehicle")
            .Produces(TypedResults.Ok().StatusCode)
            .Produces(TypedResults.NotFound().StatusCode)
            .WithSummary("Return a list of vehicles")
            .WithOpenApi();
        #endregion

        #region Get vehicle by id
        app.MapGet("api/v1/vehicles/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.VehicleContext.UseCases.SearchById.Request,
                Core.Contexts.VehicleContext.UseCases.SearchById.Response> handler) =>
        {
            var request = new Core.Contexts.VehicleContext.UseCases.SearchById.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Vehicle")
            .WithSummary("Return a vehicle according to ID")
            .WithOpenApi(opt =>
            {
                var parameter = opt.Parameters[0];
                parameter.Description = "The ID associated with the created Vehicle";
                return opt;
            });
        #endregion

        #region Get vehicle by slug
        app.MapGet("api/v1/vehicles/slug/{slug}", async (
            [FromRoute] string slug,
            [FromServices] IRequestHandler<
                Core.Contexts.VehicleContext.UseCases.SearchBySlug.Request,
                Core.Contexts.VehicleContext.UseCases.SearchBySlug.Response> handler) =>
        {
            var request = new Core.Contexts.VehicleContext.UseCases.SearchBySlug.Request(slug);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Create vehicle
        app.MapPost("api/v1/vehicles/create", async (
            [FromBody] Core.Contexts.VehicleContext.UseCases.Create.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.VehicleContext.UseCases.Create.Request,
                Core.Contexts.VehicleContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/vehicles/create/{result.Data?.vehicle.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Vehicle")
            .Produces(TypedResults.Created().StatusCode)
            .Produces(TypedResults.BadRequest().StatusCode)
            .WithOpenApi()
            .WithSummary("Create a vehicle");
        #endregion

        #region Remove vehicle
        app.MapDelete("api/v1/vehicles/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.VehicleContext.UseCases.Delete.Request,
                Core.Contexts.VehicleContext.UseCases.Delete.Response> handler) =>
        {
            var request = new Core.Contexts.VehicleContext.UseCases.Delete.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Accepted("", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}