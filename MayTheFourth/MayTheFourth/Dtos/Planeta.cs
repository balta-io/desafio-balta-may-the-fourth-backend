namespace MayTheFourth.Dtos
{
    public class Planeta
    {
        public string Nome { get; set; }
        public string PeriodoRotacao { get; set; }
        public string PeriodoOrbital { get; set; }
        public string Diametro { get; set; }
        public string Clima { get; set; }
        public string Gravidade { get; set; }
        public string Terreno { get; set; }
        public string SuperficieAquatica { get; set; }
        public string Populacao { get; set; }
        public IList<Personagem> Personagens { get; set; }
        public IList<Filme> Filmes { get; set; }
    }
}
