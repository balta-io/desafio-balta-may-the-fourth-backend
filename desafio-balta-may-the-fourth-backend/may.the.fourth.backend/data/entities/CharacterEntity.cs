using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace May.The.Fourth.Backend.Data.Entities;

[Table("Characters")]
public class CharacterEntity
{
    [Column("CharacterID", TypeName = "INT")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("Name", TypeName = "VARCHAR(255)")]
    [Required(ErrorMessage = "Nome e obrigatorio")]
    public string Name { get; set; } = String.Empty;

    [Column("Height", TypeName = "VARCHAR(50)")]
    public string? Height { get; set; }

    [Column("Weight", TypeName = "VARCHAR(50)")]
    public string? Weight { get; set; }

    [Column("HairColor", TypeName = "VARCHAR(50)")]
    public string? HairColor { get; set; }

    [Column("SkinColor", TypeName = "VARCHAR(50)")]
    public string? SkinColor { get; set; }

    [Column("EyeColor", TypeName = "VARCHAR(50)")]
    public string? EyeColor { get; set; }

    [Column("BirthYear", TypeName = "VARCHAR(50)")]
    public string? BirthYear { get; set; }

    [Column("Gender", TypeName = "VARCHAR(50)")]
    public string? Gender { get; set; }

    [Column("PlanetID", TypeName = "INT")]
    
    public int? PlanetID { get; set; }

}

