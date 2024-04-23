using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StarWars.API.Middleares.Swagger
{
    public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public SwaggerConfigureOptions(IApiVersionDescriptionProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
        }

        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IConfiguration _configuration;

        public void Configure(SwaggerGenOptions options)
        {
            // Configuração da documentação da API e possivel customização dos documentos depreciados
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));

        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var openApi = _configuration.GetSection(nameof(OpenApiInfo)).Get<OpenApiInfo>();

            var info = new OpenApiInfo()
            {
                Title = string.Format(openApi?.Title ?? string.Empty, environmentName),
                Version = string.IsNullOrEmpty(openApi?.Version) ? description.ApiVersion.ToString() : openApi.Version,
                Description = openApi?.Description,
                Contact = openApi?.Contact,
                TermsOfService = openApi?.TermsOfService,
                License = openApi?.License
            };

            if (description.IsDeprecated)
                info.Description += " Esta versão da API esta depreciada, use a versão recente.";

            return info;
        }
    }
}
