using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MayTheFourth
{
    public class Veiculo
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Nome não deve exceder 255 caracteres.")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Modelo não deve exceder 255 caracteres.")]
        public string Modelo { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Fabricante não deve exceder 255 caracteres.")]
        public string Fabricante { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Custo não deve exceder 255 caracteres.")]
        public string Custo { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "O Comprimento não deve exceder 255 caracteres.")]
        public string Comprimento { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A VelocidadeMaxima não deve exceder 255 caracteres.")]
        public string VelocidadeMaxima { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A Tripulacao não deve exceder 255 caracteres.")]
        public string Tripulacao { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "Os Passageiros não deve exceder 255 caracteres.")]
        public string Passageiros { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A CapacidadeCarga não deve exceder 255 caracteres.")]
        public string CapacidadeCarga { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "Os Consumiveis não deve exceder 255 caracteres.")]
        public string Consumiveis { get; set; }
        
        [Required]
        [StringLength(60, ErrorMessage = "A Classe não deve exceder 255 caracteres.")]
        public string Classe { get; set; }
        
        [JsonIgnore]
        public IList<Filme> Filmes { get; set; }
    }
}
