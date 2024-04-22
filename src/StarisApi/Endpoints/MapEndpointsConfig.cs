using StarisApi.Endpoints.Characters;
using StarisApi.Endpoints.DataBaseFeeders;

namespace StarisApi.Endpoints
{
    public static class MapEndpointsConfig
    {
        //Adicionar os endpoints aqui
        public  static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCharacterEndpoits();
            app.MapDatabaseFeederEndpoits();
            return app;
        }
    }
}
