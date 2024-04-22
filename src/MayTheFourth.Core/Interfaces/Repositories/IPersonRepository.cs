using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPersonRepository
{
    Task<List<Person>> GetAllAsync();
}
