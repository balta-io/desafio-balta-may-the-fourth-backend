using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Data;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
