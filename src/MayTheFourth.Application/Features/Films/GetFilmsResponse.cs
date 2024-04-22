namespace MayTheFourth.Application.Features.Films
{
    public class GetFilmsResponse
    {
        public int FilmeId { get; set; }
        public string Title { get; set; } = null!;
        public string Episode { get; set; } = null!;
        public string OpeningCrawl { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Producer { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }
}
