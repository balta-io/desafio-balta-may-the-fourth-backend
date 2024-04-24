namespace MayTheFourth.Dtos
{
    public class Filme
    {
        public string Titulo { get; set; }
        public int Episodio { get; set; }
        public string Diretor { get; set; }
        public string Produtor { get; set; }
        public DateTime DataLancamento { get; set; }
        public IList<Personagem> Personagens { get; set; }
        public IList<Planeta> Planetas { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
        public IList<NavesEstelares> Naves { get; set; }
    }
}
