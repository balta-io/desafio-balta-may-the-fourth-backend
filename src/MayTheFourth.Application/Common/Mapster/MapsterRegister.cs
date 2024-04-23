using Mapster;
using MayTheFourth.Application.Features.Films;
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
                .Map(dest => dest.ReleaseDate, src => src.Release_date);
        }
    }
}
