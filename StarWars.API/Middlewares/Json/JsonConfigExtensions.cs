using System.Text.Json;
using System.Text.Json.Serialization;

namespace StarWars.API.Middleares.Json
{
    public static class JsonConfigExtensions
    {
        public static IServiceCollection AddJsonConfig(this IServiceCollection services)
        {
            #region - Formattingg And Idented -
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
                options.JsonSerializerOptions.WriteIndented = true;
                // Faz com que o json não retorna null, mais sim vazio
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                // Retorna em minusculo o nome de todas as propriedades
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                // Força a converção de minusculo o nome de todas as propriedades
                options.JsonSerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
            })
            .AddXmlSerializerFormatters(); // Garante que a aplicação pode gerar xml ou json
            #endregion

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true); // faz com que os endpoints tenham apenas letras minusculas

            return services;
        }
    }

    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }
}
