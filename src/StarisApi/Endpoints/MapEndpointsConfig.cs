using StarisApi.Dtos;
using StarisApi.Endpoints.Characters;
using StarisApi.Endpoints.DataBaseFeeders;
using StarisApi.Models.Planets;

namespace StarisApi.Endpoints
{
    public static class MapEndpointsConfig
    {
        //Adicionar os endpoints aqui
        public  static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCharacterEndpoits();
            app.MapGenericEndpoint<Planet, PlanetDto>();
            app.MapDatabaseFeederEndpoits();
            return app;
        }
    }
}
