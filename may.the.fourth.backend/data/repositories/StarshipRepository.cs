using May.The.Fourth.Backend.Data.Contexts;
using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Interfaces;

namespace May.The.Fourth.Backend.Data.Repositories;

public class StarshipRepository(StarWarsContext ctx) : IStarshipRepository
{
    public async Task<IList<StarshipEntity>> GetStarships()
    {
        try
        {
            IQueryable<StarshipEntity> starships = await Task.FromResult(ctx.Starships);
            return starships.ToList();
        }
        catch (Exception e)
        {
            throw new Exception($"An error has occurred. Contact your admins and give them this reference: {e.StackTrace}");
        }
    }
}