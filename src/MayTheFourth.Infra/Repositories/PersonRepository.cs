using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<List<Person>> GetAllAsync()
            => await _appDbContext
                    .Persons
                    .AsNoTracking()
                    .ToListAsync();
        public async Task<bool> AnyAsync(string name, string birthYear)
            => await _appDbContext.Persons.AnyAsync(x => x.Name == name && x.BirthYear.Equals(birthYear));

    }
}
