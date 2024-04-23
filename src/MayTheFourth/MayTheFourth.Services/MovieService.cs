using MayTheFourth.Entities;
using MayTheFourth.Repositories.Repositories.Interfaces;
using MayTheFourth.Services.Interfaces;
using MayTheFourth.Services.ViewModels;

namespace MayTheFourth.Services
{
    public class MovieService(IMovieRepository repository) : 
        BaseService<MovieVM, Movie>(repository, repository),
        IMovieService
    {
    }
}
