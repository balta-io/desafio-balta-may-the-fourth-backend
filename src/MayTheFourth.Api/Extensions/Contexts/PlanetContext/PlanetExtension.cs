using MediatR;

namespace MayTheFourth.Api.Extensions.Contexts.PlanetContext;

public static class PlanetExtension
{
    public static void AddPlanetContext(this WebApplicationBuilder builder)
    {
        #region Get all planets
        builder.Services.AddTransient<Core.Interfaces.Repositories.IPlanetRepository, Infra.Repositories.PlanetRepository>();
        #endregion
    }

    public static void MapPlanetEndpoints(this WebApplication app)
    {
        #region Get all planets
        app.MapGet("api/v1/planets", async
            (IRequestHandler<Core.Contexts.PlanetContext.UseCases.SearchAllPlanets.Request,
            Core.Contexts.PlanetContext.UseCases.SearchAllPlanets.Response> handler) =>
        {
            var request = new Core.Contexts.PlanetContext.UseCases.SearchAllPlanets.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
