using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Starship : Entity
{
    public decimal HyperdriveRating { get; set; }
    public int MaximumMegalights { get; set; }

    //EF Relation
    Vehicle? Vehicle { get; set; }  //por que não public?

    public List<StarshipFilm>? Films { get; init; }
}

