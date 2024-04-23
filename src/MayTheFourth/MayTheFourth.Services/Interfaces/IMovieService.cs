using MayTheFourth.Entities;
using MayTheFourth.Services.ViewModels;

namespace MayTheFourth.Services.Interfaces
{
    public interface IMovieService : 
        IBaseReaderService<MovieVM, Movie>,
        IBaseWriterService<MovieVM, Movie>,
        IErrorBaseService
    {
    }
}
