using MayTheFourth.Core.Entities;
using MayTheFourth.Infra.Data;
using MayTheFourth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Services.DataImportService
{
    public class JsonFileImportService : IDataImportService
    {
        private readonly AppDbContext _appDbContext;
        public string FileName { get; set; } = string.Empty;

        public JsonFileImportService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task ImportDataAsync()
        {
            try
            {
                using (var stream = File.OpenRead(FileName))
                {
                    using (JsonDocument doc = await JsonDocument.ParseAsync(stream))
                    {
                        JsonElement root = doc.RootElement;
                        foreach (JsonElement element in root.EnumerateArray())
                        {
                            switch (element.GetProperty("Endpoint").GetString())
                            {
                                case "people":
                                    JsonElement data = element.GetProperty("Data");
                                    JsonElement results = data.GetProperty("results");
                                    List<PersonDTO> people = JsonSerializer.Deserialize<List<PersonDTO>>(results.GetRawText())!;

                                    foreach(var personDTO in people)
                                    {
                                        await _appDbContext.People.AddAsync(personDTO.ToPerson());
                                    }
                                    await _appDbContext.SaveChangesAsync();
                                    break;
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
