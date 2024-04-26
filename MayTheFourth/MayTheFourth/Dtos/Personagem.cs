using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MayTheFourth.Dtos
{
    public class Personagem
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Nome não deve exceder 255 caracteres.")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A Altura não deve exceder 255 caracteres.")]
        public string Altura { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Peso não deve exceder 255 caracteres.")]
        public string Peso { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A CorCabelo não deve exceder 255 caracteres.")]
        public string CorCabelo { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A CorPele não deve exceder 255 caracteres.")]
        public string CorPele { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A CorOlhos não deve exceder 255 caracteres.")]
        public string CorOlhos { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A DataNascimento não deve exceder 255 caracteres.")]
        public string DataNascimento { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Genero não deve exceder 255 caracteres.")]
        public string Genero { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Planeta não deve exceder 255 caracteres.")]
        public Planeta Planeta { get; set; }
        
        public IList<Filme> Filmes { get; set; }
    }
}
