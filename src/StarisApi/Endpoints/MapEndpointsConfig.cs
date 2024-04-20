using StarisApi.Endpoints.Characters;

namespace StarisApi.Endpoints
{
    public static class MapEndpointsConfig
    {
        //Adicionar os endpoints aqui
        public  static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCharacterEndpoits();

            return app;
        }
    }
}
