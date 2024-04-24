using Microsoft.OpenApi.Models;
using System.Reflection;

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
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
app.UseSwagger();

app.MapGet("/", () => "Hello World!");

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Star Wars API");
    // Tip: To serve the Swagger UI at the app's root (https://localhost:<port>/), set the RoutePrefix property to an empty string
    options.RoutePrefix = string.Empty;
});

app.Run();
