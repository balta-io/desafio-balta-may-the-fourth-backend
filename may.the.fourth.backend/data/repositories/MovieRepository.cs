using May.The.Fourth.Backend.Data.Contexts;
using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Interfaces;

namespace May.The.Fourth.Backend.Data.Repositories;

public class MovieRepository(StarWarsContext ctx) : IMovieRepository
{
    public async Task<IList<MovieEntity>> GetMovies()
    {
        try
        {
            IQueryable<MovieEntity> movies = await Task.FromResult(ctx.Movies);
            return movies.ToList();
        }
        catch (Exception e)
        {
            throw new Exception($"An error has occurred. Contact your admins and give them this reference: {e.StackTrace}");
        }
    }
}