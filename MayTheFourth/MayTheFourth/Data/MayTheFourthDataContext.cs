using MayTheFourth.Data.Mappings;
using MayTheFourth.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Data;

public class MayTheFourthDataContext : DbContext
{
    public MayTheFourthDataContext(DbContextOptions<MayTheFourthDataContext> options) : base(options){}
    
    public DbSet<Filme> Filmes { get; set; }
    
    public DbSet<NavesEstelares> NavesEstelares { get; set; }
    
    public DbSet<Personagem> Personagens { get; set; }
    
    public DbSet<Planeta> Planetas { get; set; }
    
    public DbSet<Veiculo> Veiculos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmeMap());
        modelBuilder.ApplyConfiguration(new NavesEstelaresMap());
        modelBuilder.ApplyConfiguration(new PersonagemMap());
        modelBuilder.ApplyConfiguration(new PlanetasMap());
        modelBuilder.ApplyConfiguration(new VeiculosMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=maythefourth.db;Cache=Shared");
}