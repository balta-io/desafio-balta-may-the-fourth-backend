using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PersonContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;
using MayTheFourth.Api.Extensions.Contexts.SpeciesContext;
using MayTheFourth.Api.Extensions.Contexts.StartshipContext;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddPlanetContext();
builder.AddStarshipContext();
builder.AddFilmContext();
builder.AddPersonContext();
builder.AddSpeciesContext();
builder.AddDbContext();
builder.AddDataImport();
builder.AddMediatR();

builder.Services.Configure<JsonOptions>(opt => opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "MayTheFourth API - Rebel Renegades", 
        Version = "v1",
        Description = "API para consulta de dados do universo de Star Wars",
        Contact = new OpenApiContact
        {
            Name = "Capitão Igor",
            Url = new Uri("https://github.com/igorsantiiago/desafio-balta-may-the-fourth-backend")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

builder.Services.ConfigureSwaggerGen(options => options.CustomSchemaIds(x => x.FullName));

var app = builder.Build();

app.UseSwagger();
app.MapSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MayTheFourth API V1");
});

app.UseHttpsRedirection();

var resourceFileName = builder.Configuration["ImportSettings:ResourceFileName"];

await app.ImportDataAsync(resourceFileName!);

app.MapPlanetEndpoints();
app.MapStarshipEndpoints();
app.MapFilmEndpoints();
app.MapPersonEndpoints();
app.MapSpeciesEndpoints();

app.Run();