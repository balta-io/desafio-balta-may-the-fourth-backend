using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Starship : Entity
{
    public int VehicleId { get; set; }
    public decimal HyperdriveRating { get; set; }
    public int MaximumMegalights { get; set; }

    //EF Relation
    public Vehicle? Vehicle { get; init; }

	public List<FilmVehicle>? Movies { get; init; }  //Filtrar somento os Vehicle.Types == Starthip
}

