using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Data.Interfaces;

public interface IMoviepository
{
    Task<IList<MovieEntity>> GetMovies();
}