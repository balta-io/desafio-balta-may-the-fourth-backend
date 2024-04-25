using Microsoft.EntityFrameworkCore;

using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Factories;

namespace May.The.Fourth.Backend.Data.Contexts;

public class StarWarsContext(DbContextOptions<StarWarsContext> options) : DbContext(options)
{
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<StarshipEntity> Starships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       MovieFactory.Execute(modelBuilder);
       StarShipFactory.Execute(modelBuilder);
    }
}