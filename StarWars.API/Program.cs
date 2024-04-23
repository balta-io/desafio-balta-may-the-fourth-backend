using StarWars.API.Endpoints.Abstracts;
using StarWars.API.Middlewares;
using StarWars.API.Services.Abstracts;
using StarWars.API.Storages.Abstracts;

namespace StarWars.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMiddlewares();
        builder.Services.AddServiceDependences();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddStorageDependences(builder.Configuration);


        var app = builder.Build();

        if (app.Environment.IsProduction())
        {
            //Força o uso de https 
            app.Use((context, next) =>
            {
                context.Request.Scheme = "https";
                return next();
            });
        }

        app.UseEndpoints();
        app.UseMiddlewares();
        app.UseHttpsRedirection();

        app.Run();
    }
}

