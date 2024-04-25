using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Tests.Repositories
{
    public class FakeFilmRepository : IFilmRepository
    {
        public async Task<List<Film>> GetAllAsync()
        {
            List<Film> films = new List<Film>();
            films.Add(new Film { Created = DateTime.Now, Director = "Igor", Edited = DateTime.Now, Title = "Filme 01" });
            films.Add(new Film { Created = DateTime.Now, Director = "Eduardo", Edited = DateTime.Now, Title = "Filme 02" });
            films.Add(new Film { Created = DateTime.Now, Director = "Erik", Edited = DateTime.Now, Title = "Filme 03" });
            films.Add(new Film { Created = DateTime.Now, Director = "Everson", Edited = DateTime.Now, Title = "Filme 04" });
            films.Add(new Film { Created = DateTime.Now, Director = "Lucas", Edited = DateTime.Now, Title = "Filme 05" });

            await Task.Delay(10);
            return films;
        }

        public Task<Film?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
