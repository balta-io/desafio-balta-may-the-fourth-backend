using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Planet> Planets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
