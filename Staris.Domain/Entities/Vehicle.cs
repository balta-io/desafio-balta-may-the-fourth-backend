using Staris.Domain.Common;
using Staris.Domain.Enumerables;

namespace Staris.Domain.Entities;

public class Vehicle : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public decimal Lenght { get; set; }
    public decimal MaxSpeed { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public decimal CargoCapacity { get; set; }
    public int Consumables { get; set; }
    public string Class { get; set; } = string.Empty;

    public EnumTypeOfVehicle Type { get; set; }


    //EF Relational
    public Starship? Starship { get; init; }

    public List<FilmVehicle>? Films { get; init; } //Filtrar somento os Types == Vehicle
}
