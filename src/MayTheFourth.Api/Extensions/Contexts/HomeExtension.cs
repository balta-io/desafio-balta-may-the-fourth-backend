using MayTheFourth.Core.Contexts.SharedContext.UseCases;
using System.Net;

namespace MayTheFourth.Api.Extensions.Contexts
{
    public static class HomeExtension
    {
        public static void MapHomeEndpoint(this WebApplication app)
        {
            app.MapGet("/", () => 
            {
                return Results.Redirect("/swagger");
            });

        }
    }
}
