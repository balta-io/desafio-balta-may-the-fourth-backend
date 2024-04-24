using Mapster;
using MayTheFourth.Application.Features.Films;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.Mapster
{
    public class MapsterRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<FilmEntity, GetFilmsResponse>()
                .Map(dest => dest.Episode, src => src.Episode_id)
                .Map(dest => dest.OpeningCrawl, src => src.Opening_crawl)
                .Map(dest => dest.ReleaseDate, src => src.Release_date)
                .Ignore(dest => dest.Characters)
                .Ignore(dest => dest.Planets)
                .Ignore(dest => dest.Vehicles)
                .Ignore(dest => dest.Starships);

        }
    }
}
