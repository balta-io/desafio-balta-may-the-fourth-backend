namespace MayTheFourth.Application.Features.Films
{
    public class GetFilmsResponse
    {
        public string Title { get; set; } = null!;
        public string Episode { get; set; } = null!;
        public string OpeningCrawl { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Producer { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public List<ItemDescription> Characters { get; set; }
        public List<ItemDescription> Planets { get; set; }
        public List<ItemDescription> Vehicles { get; set; }
        public List<ItemDescription> Starships { get; set; }

    }

    public class ItemDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
