using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Data.Interfaces;

public interface IStarshipRepository
{
    Task<IList<StarshipEntity>> GetStarships();
}
