using StarisApi.Models.Planets;

namespace StarisApi.Dtos
{
    /// <summary>
    /// teste
    /// </summary>
    public sealed class MovieDTO : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Episode { get; set; } = null!;
        public string OpeningCrawl { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Production { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public ICollection<ListDto> Characters { get; set; } = null!;
        public ICollection<ListDto> Planets { get; set; } = null!;
        public ICollection<ListDto> Vehicles { get; set; } = null!;
        public ICollection<ListDto> Starships { get; set; } = null!;

    }
}
