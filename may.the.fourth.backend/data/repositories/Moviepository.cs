using May.The.Fourth.Backend.Data.Contexts;
using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Interfaces;

namespace May.The.Fourth.Backend.Data.Repositories;

public class Moviepository(StarWarsContext ctx) : IMoviepository
{
    public async Task<IList<MovieEntity>> GetMovies()
    {
        try
        {
            IQueryable<MovieEntity> films = await Task.FromResult(ctx.Filmes);
            return films.ToList();
        }
        catch (Exception e)
        {
            throw new Exception($"An error has occurred. Contact your admins and give them this reference: {e.StackTrace}");
        }
    }
}