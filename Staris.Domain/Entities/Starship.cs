using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Starship : Entity
{
    public decimal hyperdriveRating { get; set; }
    public int MaximumMegalights { get; set; }

    //EF Relation
    Vehicle? Vehicle { get; set; }  
}

