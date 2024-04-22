using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Planet> Planets { get; set; }
    public DbSet<Starship> Starships { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
