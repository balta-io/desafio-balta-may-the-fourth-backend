using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PersonContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;
using MayTheFourth.Api.Extensions.Contexts.StartshipContext;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddPlanetContext();
builder.AddStarshipContext();
builder.AddFilmContext();
builder.AddPersonContext();
builder.AddDbContext();
builder.AddMediatR();
builder.AddDataImport();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.ImportDataAsync();
app.MapPlanetEndpoints();
app.MapStarshipEndpoints();
app.MapFilmEndpoints();
app.MapPersonEndpoints();

app.Run();