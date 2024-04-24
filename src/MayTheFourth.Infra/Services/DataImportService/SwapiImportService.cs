using MayTheFourth.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Services.DataImportService
{
    public class SwapiImportService : IDataImportService
    {
        private readonly AppDbContext _appDbContext;
        public string Url { get; set; } = string.Empty;

        public SwapiImportService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task ImportDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
