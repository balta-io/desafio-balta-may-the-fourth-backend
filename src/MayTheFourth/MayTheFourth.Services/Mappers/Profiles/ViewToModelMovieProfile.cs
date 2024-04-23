using AutoMapper;
using MayTheFourth.Entities;
using MayTheFourth.Services.ViewModels;
using MayTheFourth.Utils.Paging;

namespace MayTheFourth.Services.Mappers.Profiles
{
    public class ViewToModelMovieProfile: Profile
    {
        public ViewToModelMovieProfile()
        {
            CreateMap<MovieVM, Movie>();
            CreateMap<PageListResult<MovieVM>, PageListResult<Movie>>();
        }
    }
}
