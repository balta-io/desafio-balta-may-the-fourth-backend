using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PersonContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;
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
builder.AddDbContext();
builder.AddDataImport();
builder.AddMediatR();

builder.Services.Configure<JsonOptions>(opt => opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(api =>
{
    api.SwaggerDoc("v1", new()
    {
        Title = "MayTheFourth - MT4BWY",
        Version = "v1",
        Description = "API para consulta de dados do universo de Star Wars",
        TermsOfService = new Uri("https://go.balta.io/may-the-fourth"),
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

    api.CustomSchemaIds(type => type.FullName);

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    api.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var importFileName = builder.Configuration["ImportSettings:FileName"];

await app.ImportDataAsync(importFileName!);
app.MapPlanetEndpoints();
app.MapStarshipEndpoints();
app.MapFilmEndpoints();
app.MapPersonEndpoints();

app.Run();