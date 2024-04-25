using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Data.Repositories;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services;
using May.The.Fourth.Backend.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    {
        Title = "Star Wars API",
        Version = "v1",
        Description = "An ASP.NET Core Web API for getting information about Star Wars world",
        TermsOfService = new Uri("https://star-wars-balta.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Paulo Pimenta",
            Url = new Uri("https://star-wars-balta.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Star Wars Balta License",
            Url = new Uri("https://star-wars-balta.com/license")
        }
    });
    // Add XML comments to swagger.
    // Using System.Reflection;
    var xmlMoviename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlMoviename));
});
builder.Services.AddScoped<IMoviepository, Moviepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddEntityFrameworkNpgsql();
var connection = builder.Configuration.GetConnectionString("StarWarsConnection");
builder.Services.AddDbContextPool<StarWarsContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
app.UseSwagger();

// app.MapGet("/", () => "Hello World!");

// endpoints
var endpoints = app.MapGroup("/star-wars");
endpoints.MapGet("/", () => "Hello Star Wars World!");
endpoints.MapGet("/filmes", GetMovies);

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Star Wars API");
    // Tip: To serve the Swagger UI at the app's root (https://localhost:<port>/), set the RoutePrefix property to an empty string
    options.RoutePrefix = string.Empty;
});

app.Run();

static async Task<IResult> GetMovies(IMovieService movieService)
{
    var result = await movieService.GetMovies();
    return result.Success 
        ? TypedResults.Ok(result) 
        : TypedResults.BadRequest(result);
}