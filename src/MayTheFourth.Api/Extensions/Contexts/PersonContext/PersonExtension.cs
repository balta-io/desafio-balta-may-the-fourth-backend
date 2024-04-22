using MediatR;

namespace MayTheFourth.Api.Extensions.Contexts.PersonContext;

public static class PersonExtension
{
    public static void AddPersonContext(this WebApplicationBuilder builder)
    {
        #region Register Person Repository
        builder.Services.AddTransient
            <Core.Interfaces.Repositories.IPersonRepository,
            Infra.Repositories.PersonRepository>();
        #endregion
    }

    public static void MapPersonEndpoints(this WebApplication app)
    {
        #region Get all persons
        app.MapGet("api/v1/person", async
            (IRequestHandler<Core.Contexts.PersonContext.UseCases.SearchAll.Request,
            Core.Contexts.PersonContext.UseCases.SearchAll.Response> handler) =>
        {
            var request = new Core.Contexts.PersonContext.UseCases.SearchAll.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
