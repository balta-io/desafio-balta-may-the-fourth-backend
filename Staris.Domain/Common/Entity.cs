﻿namespace Staris.Domain.Common;

public abstract class Entity
{
    public int Id { get; init; }

    public Entity() { }

    public Entity(int id)
    {
        Id = id;
    }
}
