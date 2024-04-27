using MayTheFourth.Core.Entities;
using MayTheFourth.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Starship> Starships { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlanetMap());
        modelBuilder.ApplyConfiguration(new StarshipMap());
        modelBuilder.ApplyConfiguration(new FilmMap());
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new SpeciesMap());
        modelBuilder.ApplyConfiguration(new VehicleMap());
    }
}
