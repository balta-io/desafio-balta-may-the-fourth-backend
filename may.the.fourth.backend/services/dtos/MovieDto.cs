namespace May.The.Fourth.Backend.Services.Dtos;

    public class MovieDto
    {
        public int Id { get; set; }        
        public string Title { get; set; } = string.Empty;
        public int? Episode { get; set; }
        public string? OpeningCrawl { get; set; }
        public string? Director { get; set; }
        public string? Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
