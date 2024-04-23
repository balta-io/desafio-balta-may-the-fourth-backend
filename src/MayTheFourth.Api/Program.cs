using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PersonContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;
using MayTheFourth.Api.Extensions.Contexts.StartshipContext;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddPlanetContext();
builder.AddStarshipContext();
builder.AddFilmContext();
builder.AddPersonContext();
builder.AddDbContext();
builder.AddMediatR();

builder.Services.Configure<JsonOptions>(opt => opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPlanetEndpoints();
app.MapStarshipEndpoints();
app.MapFilmEndpoints();
app.MapPersonEndpoints();

app.Run();