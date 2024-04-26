using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MayTheFourth.Dtos
{
    public class Filme
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "O Titulo não deve exceder 255 caracteres.")]
        public string Titulo { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "O Episodio não deve exceder 255 caracteres.")]
        public int Episodio { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Diretor não deve exceder 255 caracteres.")]
        public string Diretor { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Produtor não deve exceder 255 caracteres.")]
        public string Produtor { get; set; }
        
        [Required]
        [Range(1900, 2100, ErrorMessage = "DataLancamento deve estar entre 1900 e 2100.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "A data deve ser um número de 4 dígitos.")]
        public DateTime  DataLancamento { get; set; }
        
        [JsonIgnore]
        public IList<Personagem> Personagens { get; set; }
        
        [JsonIgnore]
        public IList<Planeta> Planetas { get; set; }
        
        [JsonIgnore]
        public IList<Veiculo> Veiculos { get; set; }
        
        [JsonIgnore]
        public IList<NavesEstelares> Naves { get; set; }
    }
}
