using LotoBackend.IOC;
using MayTheFourth.WebApi.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
                     new OpenApiInfo
                     {
                         Version = "v1",
                         Title = "May The Fourth",
                         Description = "App created for Balta.IO Challenge"
                     });

        c.EnableAnnotations();
    }
 );

// Dependency Injections
ConfigureBindingsDependencyInjection.RegisterBindings(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Endpoints
app.MapFilmesEndpoints();
app.MapNavesEndpoints();
app.MapPersonagensEndpoints();
app.MapPlanetasEndpoints();
app.MapVeiculosEndpoints();

app.Run();
