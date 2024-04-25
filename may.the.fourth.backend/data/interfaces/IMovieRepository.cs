using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Data.Interfaces;

public interface IMovieRepository
{
    Task<IList<MovieEntity>> GetMovies();
}
