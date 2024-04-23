using AutoMapper;
using MayTheFourth.Entities;
using MayTheFourth.Services.ViewModels;
using MayTheFourth.Utils.Paging;

namespace MayTheFourth.Services.Mappers.Profiles
{
    public class ModelToViewMovieProfile: Profile
    {
        public ModelToViewMovieProfile()
        {
            CreateMap<Movie, MovieVM>();
            CreateMap<PageListResult<Movie>, PageListResult<MovieVM>>();
        }
    }
}
