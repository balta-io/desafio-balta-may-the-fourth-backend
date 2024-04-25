using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace May.The.Fourth.Backend.Data.Entities;

[Table("Movies")]
public class MovieEntity
{
    [Column("Id", TypeName = "INT")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    [Column("Title", TypeName = "VARCHAR(500)")]
    [Required(ErrorMessage = "Titulo e obrigatorio")]
    public string Title { get; set; } = string.Empty;

    [Column("Episode", TypeName = "INT")]
    public int? Episode { get; set; }

    [Column("OpeningCrawl", TypeName = "TEXT")]
    public string? OpeningCrawl { get; set; }

    [Column("Director", TypeName = "VARCHAR(150)")]
    public string? Director { get; set; }

    [Column("Producer", TypeName = "VARCHAR(150)")]
    public string? Producer { get; set; }

    [Column("ReleaseDate", TypeName = "DATE")]
    public DateTime? ReleaseDate { get; set; }
}