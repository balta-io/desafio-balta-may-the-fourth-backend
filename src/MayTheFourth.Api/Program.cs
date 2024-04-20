using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;

var builder = WebApplication.CreateBuilder(args);

builder.AddPlanetContext();
builder.AddFilmContext();
builder.AddDbContext();
builder.AddMediatR();
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
app.MapFilmEndpoints();

app.Run();