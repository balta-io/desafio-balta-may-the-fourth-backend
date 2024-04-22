using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;

namespace MayTheFourth.Tests.Repositories
{
    public class FakePersonRepository : IPersonRepository
    {
        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> people = new List<Person>()
        {
            new Person(){ Name = "Obi-Wan Kenobi", BirthYear = "57BBY"},
            new Person(){ Name = "Anakin Skywalker", BirthYear = "41.9BBY"},
            new Person(){ Name = "Chewbacca", BirthYear = "200BBY"},
            new Person(){ Name = "Han Solo", BirthYear = "29BBY"},
            new Person(){ Name = "Yoda", BirthYear = "896BBY"},

        };
            await Task.Delay(10);
            return people;
        }
    }
}
