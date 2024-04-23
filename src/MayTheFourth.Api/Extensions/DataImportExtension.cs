using MayTheFourth.Infra.Data;
using MayTheFourth.Infra.Services.DataImportService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace MayTheFourth.Api.Extensions
{
    public static class DataImportExtension
    {
        public static void AddDataImport(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDataImportService, JsonFileImportService>();
        }

        public static async Task ImportDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataImportService = (JsonFileImportService) scope.ServiceProvider.GetRequiredService<IDataImportService>();

            dataImportService.FileName = @"C:\\boca\\cursos\\balta\\desafio-balta-may-the-fourth-backend\\src\\MayTheFourth.Infra\\bin\\Debug\\net8.0\\swapi_data.json";
            await dataImportService.ImportDataAsync();
        }
    }
}
