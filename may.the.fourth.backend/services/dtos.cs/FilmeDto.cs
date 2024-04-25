namespace May.The.Fourth.Backend.Services.Mappers
{
    public class FilmeDto
    {
        public int Id { get; set; }        
        public string Titulo { get; set; } = String.Empty;
        public int? Episodio { get; set; }
        public string? TextoAbertura { get; set; }
        public string? Diretor { get; set; }
        public string? Produtor { get; set; }
        public DateTime? DataLancamento { get; set; }
    }
}