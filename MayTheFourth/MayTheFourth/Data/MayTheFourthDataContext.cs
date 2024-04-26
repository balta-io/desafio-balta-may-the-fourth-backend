using MayTheFourth.Data.Mappings;
using MayTheFourth.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Data;

/// <summary>
/// Contexto do Entity Framework representando a conexão com o banco de dados e o modelo para o sistema MayTheFourth.
/// Este contexto inclui conjuntos de dados para Filmes, Naves Estelares, Personagens, Planetas e Veículos.
/// </summary>
public class MayTheFourthDataContext : DbContext
{
    /// <summary>
    /// Inicializa uma nova instância da classe MayTheFourthDataContext com as opções configuradas.
    /// </summary>
    /// <param name="options">As opções de configuração para o contexto do DbContext.</param>
    public MayTheFourthDataContext(DbContextOptions<MayTheFourthDataContext> options) : base(options){}
    
    /// <summary>
    /// Representa uma coleção de filmes no banco de dados.
    /// </summary>
    public DbSet<Filme> Filmes { get; set; }

    /// <summary>
    /// Representa uma coleção de naves estelares no banco de dados.
    /// </summary>
    public DbSet<NavesEstelares> NavesEstelares { get; set; }

    /// <summary>
    /// Representa uma coleção de personagens no banco de dados.
    /// </summary>
    public DbSet<Personagem> Personagens { get; set; }
    
    /// <summary>
    /// Representa uma coleção de planetas no banco de dados.
    /// </summary>
    public DbSet<Planeta> Planetas { get; set; }
    
    /// <summary>
    /// Representa uma coleção de veiculos no banco de dados.
    /// </summary>
    public DbSet<Veiculo> Veiculos { get; set; }
    
    /// <summary>
    /// Aplica configurações de mapeamento para cada entidade ao criar o modelo de banco de dados.
    /// </summary>
    /// <param name="modelBuilder">O construtor de modelos para configurar as entidades mapeadas.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmeMap());
        modelBuilder.ApplyConfiguration(new NavesEstelaresMap());
        modelBuilder.ApplyConfiguration(new PersonagemMap());
        modelBuilder.ApplyConfiguration(new PlanetasMap());
        modelBuilder.ApplyConfiguration(new VeiculosMap());
    }

    /// <summary>
    /// Configura o contexto para usar um banco de dados SQLite com o arquivo especificado.
    /// </summary>
    /// <param name="options">Construtor de opções para configurar o contexto.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=maythefourth.db;Cache=Shared");
}