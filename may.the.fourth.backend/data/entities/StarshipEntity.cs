using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace May.The.Fourth.Backend.Data.Entities;

[Table("Starships")]
public class StarshipEntity
{
    [Column("Id", TypeName = "INT")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    [Column("Name", TypeName = "VARCHAR(255)")]
    [Required(ErrorMessage = "Titulo e obrigatorio")]
    public string Name { get; set; } = string.Empty;

    [Column("Model", TypeName = "VARCHAR(255)")]
    public string? Model { get; set; }

    [Column("Manufacturer", TypeName = "VARCHAR(255)")]
    public string? Manufacturer { get; set; }
    
    [Column("CostInCredits", TypeName = "VARCHAR(50)")]
    public string? CostInCredits { get; set; }

    [Column("Length", TypeName = "VARCHAR(50)")]
    public string? Length { get; set; }
    
    [Column("MaxSpeed", TypeName = "VARCHAR(50)")]
    public string? MaxSpeed { get; set; }

    [Column("Crew", TypeName = "VARCHAR(50)")]
    public string? Crew { get; set; }
    
    [Column("Passengers", TypeName = "VARCHAR(50)")]
    public string? Passengers { get; set; }

    [Column("CargoCapacity", TypeName = "VARCHAR(50)")]
    public string? CargoCapacity { get; set; }
    
    [Column("HyperdriveRating", TypeName = "VARCHAR(50)")]
    public string? HyperdriveRating { get; set; }

    [Column("Mglt", TypeName = "VARCHAR(50)")]
    public string? Mglt { get; set; }
    
    [Column("Consumables", TypeName = "VARCHAR(50)")]
    public string? Consumables { get; set; }

    [Column("Class", TypeName = "VARCHAR(50)")]
    public string? Class { get; set; }
    
}