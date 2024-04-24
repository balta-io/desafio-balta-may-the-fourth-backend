using MayTheFourth.Infra.Services.DataImportService;

namespace MayTheFourth.Api.Extensions.Contexts
{
    public static class DataImportExtension
    {
        public static void AddDataImport(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDataImportService, JsonFileImportService>();
        }

        public static async Task ImportDataAsync(this WebApplication app, string FileName)
        {
            using var scope = app.Services.CreateScope();
            var dataImportService = (JsonFileImportService)scope.ServiceProvider.GetRequiredService<IDataImportService>();

            dataImportService.FileName = FileName;
            await dataImportService.ImportDataAsync();
        }
    }
}
