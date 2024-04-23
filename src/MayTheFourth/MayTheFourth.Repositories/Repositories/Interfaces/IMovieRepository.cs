using MayTheFourth.Entities;

namespace MayTheFourth.Repositories.Repositories.Interfaces
{
    public interface IMovieRepository :
        IBaseReaderRepository<Movie>,
        IBaseWriterRepository<Movie>
    {
    }
}
