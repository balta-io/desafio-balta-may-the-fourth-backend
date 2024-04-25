using May.The.Fourth.Backend.Services.Mappers;

namespace May.The.Fourth.Backend.Services.Messages
{
    public class FilmeListResponse : ResponseBase
    {
        public IList<FilmeDto>? FilmeDto { get; set; }
    }
}