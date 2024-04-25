using May.The.Fourth.Backend.Services.Dtos;
using May.The.Fourth.Backend.Services.Mappers;

namespace May.The.Fourth.Backend.Services.Messages
{
    public class MovieListResponse : ResponseBase
    {
        public IList<MovieDto>? FilmeDto { get; set; }
    }
}