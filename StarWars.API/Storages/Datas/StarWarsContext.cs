﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<CharacterModel> Characters { get; private set; }
        public DbSet<VehicleModel> Vehicles { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Todo: Adicionar as configurações dos outros modelos

            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new  CharacterConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}

