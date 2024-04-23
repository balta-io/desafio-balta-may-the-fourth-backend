using MayTheFourth.Entities;
using MayTheFourth.Repositories.Context;
using MayTheFourth.Repositories.Repositories.Interfaces;

namespace MayTheFourth.Repositories.Repositories
{
    public class MovieRepository(DatabaseContext context) : 
        BaseRepository<Movie>(context),
        IMovieRepository
    {
    }
}
