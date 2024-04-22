using MayTheFourth.Core.Entities;
using MayTheFourth.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Planet> Planets { get; set; }
    public DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmMap());
    }
}
