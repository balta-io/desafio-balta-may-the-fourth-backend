namespace MayTheFourth.Dtos
{
    public class Personagem
    {
        public string Nome { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string CorCabelo { get; set; }
        public string CorPele { get; set; }
        public string CorOlhos { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public Planeta Planeta { get; set; }
        public IList<Filme> Filmes { get; set; }
    }
}
