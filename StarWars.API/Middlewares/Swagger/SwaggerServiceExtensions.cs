using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerUI;
using Asp.Versioning.ApiExplorer;

namespace StarWars.API.Middleares.Swagger
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Description = "Esta API usa autenticação e autorização. Example: \"Authorization: Bearer {token}\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                });

                // Para funcionar deve ser alterado o csproj e aplicar o grupo de geração de documentação
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/docs/{documentName}/doc.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });

            app.UseSwaggerUI(options =>
            {
                var solutionName = Assembly.GetExecutingAssembly().GetName()?.Name?.Split(".").FirstOrDefault(); // Obter o nome da solution

                options.RoutePrefix = "docs";
                options.DocumentTitle = $"{solutionName} - Documentação da API Rest"; // Titulo do separador do browser
                options.EnableFilter();
                options.DisplayRequestDuration();
                options.DocExpansion(DocExpansion.None);


                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>(); // Obter o provedor de versões da API

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/docs/{description.GroupName}/doc.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
