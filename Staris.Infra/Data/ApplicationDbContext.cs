using Microsoft.EntityFrameworkCore;
using Staris.Application.Data;
using Staris.Domain.Entities;

namespace Staris.Infra.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{

    public DbSet<Character> Characters { get; set; } 
    public DbSet<CharacterFilm> CharacterFilms { get; set; }
    public DbSet<CharacterPlanet> CharacterPlanets { get; set; }
    public DbSet<Film> Films { get; set; }  
    public DbSet<Planet> Planets { get; set;}
    public DbSet<PlanetFilm> PlanetFilms{ get; set; }
    public DbSet<Starship> Starships { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }



    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//Adding configuration from mapping classes
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}


	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var response = await base.SaveChangesAsync(cancellationToken);
        return response;
    }

}
