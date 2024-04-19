namespace MayTheFourth.Core.Entities;

public class Film
{
    public string Title { get; set; } = string.Empty;
    public int EpisodeId { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string[] Species { get; set; } = [];
    public string[] Starships { get; set; } = [];
    public string[] Vehicles { get; set; } = [];
    public string[] Characters { get; set; } = [];
    public string[] Planets { get; set; } = [];
    public string Url { get; set; } = string.Empty;
    public string Created { get; set; } = string.Empty;
    public string Edited { get; set; } = string.Empty;
}
