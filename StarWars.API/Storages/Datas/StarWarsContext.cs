using Microsoft.EntityFrameworkCore;
using StarWars.API.Models;
using StarWars.API.Storages.Datas.EntityConfigurations;

namespace StarWars.API.Storages.Datas
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options)
        {
        }

        #region - Configuração de DbSets -
        public DbSet<MovieModel> Movies { get; private set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DbSet<CharacterModel> Characters { get; private set; }
=======
        public DbSet<VehicleModel> Vehicles { get; private set; }
>>>>>>> b2ddc7ae15114156d0cb2e45c2f0e61b286dea42
=======
        public DbSet<VehicleModel> Vehicles { get; private set; }
>>>>>>> b2ddc7ae15114156d0cb2e45c2f0e61b286dea42
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Todo: Adicionar as configurações dos outros modelos

<<<<<<< HEAD
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
=======
            modelBuilder.ApplyConfiguration(new MoveConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
<<<<<<< HEAD
>>>>>>> b2ddc7ae15114156d0cb2e45c2f0e61b286dea42
=======
>>>>>>> b2ddc7ae15114156d0cb2e45c2f0e61b286dea42

            base.OnModelCreating(modelBuilder);
        }


    }
}

