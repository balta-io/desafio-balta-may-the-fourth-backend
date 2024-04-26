using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MayTheFourth.Dtos
{
    public class Planeta
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Nome não deve exceder 255 caracteres.")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O PeriodoRotacao não deve exceder 255 caracteres.")]
        public string PeriodoRotacao { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O PeriodoOrbital não deve exceder 255 caracteres.")]
        public string PeriodoOrbital { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Diametro não deve exceder 255 caracteres.")]
        public string Diametro { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Clima não deve exceder 255 caracteres.")]
        public string Clima { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A Gravidade não deve exceder 255 caracteres.")]
        public string Gravidade { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Terreno não deve exceder 255 caracteres.")]
        public string Terreno { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A SuperficieAquatica não deve exceder 255 caracteres.")]
        public string SuperficieAquatica { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A Populacao não deve exceder 255 caracteres.")]
        public string Populacao { get; set; }
        
        [JsonIgnore]
        public IList<Personagem> Personagens { get; set; }
        
        [JsonIgnore]
        public IList<Filme> Filmes { get; set; }
    }
}
