using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace May.The.Fourth.Backend.Data.Entities
{
    [Table("Filmes")]
    public class FilmeEntity
    {
        [Column("FilmeID", TypeName = "INT")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("Titulo", TypeName = "VARCHAR(500)")]
        [Required(ErrorMessage = "Titulo e obrigatorio")]
        public string Titulo { get; set; } = String.Empty;

        [Column("Episodio", TypeName = "INT")]
        public int? Episodio { get; set; }

        [Column("TextoAbertura", TypeName = "VARCHAR(500)")]
        public string? TextoAbertura { get; set; }

        [Column("Diretor", TypeName = "VARCHAR(150)")]
        public string? Diretor { get; set; }

        [Column("Produtor", TypeName = "VARCHAR(150)")]
        public string? Produtor { get; set; }

        [Column("DataLancamento", TypeName = "DATE")]
        public DateTime? DataLancamento { get; set; }
    }
}