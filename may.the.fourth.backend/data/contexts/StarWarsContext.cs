using Microsoft.EntityFrameworkCore;

using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Data.Contexts
{
    public class StarWarsContext : DbContext
    {        
        public StarWarsContext(DbContextOptions<StarWarsContext> options)
            : base(options) { }

        public DbSet<FilmeEntity> Filmes { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // filmes
            var filmes = new FilmeEntity[]
            {
                new FilmeEntity { Id = 1, Titulo = "The Rise of the Jedi", Episodio = 10, TextoAbertura = "After the fall of the Empire, the galaxy face", Diretor = "Jana Doe", Produtor = "Leo Smith", DataLancamento = new DateTime(2028, 12, 15) },
                new FilmeEntity { Id = 2, Titulo = "The Battle of the Stars" },
                new FilmeEntity { Id = 3, Titulo = "Return of the Light" },
                new FilmeEntity { Id = 4, Titulo = "Warriors of the Shadow Realm" },
                new FilmeEntity { Id = 5, Titulo = "The Galactic Quest" },
                new FilmeEntity { Id = 6, Titulo = "Rise of the Planetara" },
                new FilmeEntity { Id = 7, Titulo = "Echoes of the Stars" },
                new FilmeEntity { Id = 8, Titulo = "The Return of the Voyager" },
                new FilmeEntity { Id = 9, Titulo = "Voyager's Endgame" },
                new FilmeEntity { Id = 10, Titulo = "Galactic Odyssey" },
                new FilmeEntity { Id = 11, Titulo = "The Edge of the Universe" },
            };
            modelBuilder.Entity<FilmeEntity>().HasData(filmes);

            // characters
            var characters = new CharacterEntity[]
            {
                new CharacterEntity { Id = 1, Name = "Luke Skywalker", Height = "172", Weight = "77", HairColor = "blond", SkinColor = "fair", EyeColor = "blue", BirthYear = "19BBY", Gender = "male", PlanetID = 1 },                
                new CharacterEntity { Id = 2, Name = "C-3PO", Height = "167", Weight= "75", HairColor = "n/a", SkinColor = "gold", EyeColor = "yellow", BirthYear = "112BBY", Gender = "n/a", PlanetID = 1 },
                new CharacterEntity { Id = 3, Name = "R2-D2", Height = "96", Weight= "32", HairColor = "n/a", SkinColor = "white, blue", EyeColor="red", BirthYear = "33BBY", Gender = "n/a", PlanetID = 8 },
                new CharacterEntity { Id = 4, Name = "Darth Vader", Height = "202", Weight = "136", HairColor = "none", SkinColor = "white", EyeColor = "yellow", BirthYear = "41.9BBY", Gender = "male", PlanetID = 1 },                
                new CharacterEntity { Id = 5, Name = "Leia Organa", Height = "150", Weight = "49", HairColor = "brown", SkinColor = "light", EyeColor = "brown", BirthYear = "19BBY", Gender = "female", PlanetID = 2 },                
                new CharacterEntity { Id = 6, Name = "Owen Lars", Height = "178", Weight = "120", HairColor = "brown, grey", SkinColor= "light", EyeColor="blue", BirthYear= "52BBY", Gender= "male", PlanetID = 1 },
                new CharacterEntity { Id = 7, Name = "Beru Whitesun lars", Height = "165", Weight = "75", HairColor = "brown", SkinColor = "light", EyeColor = "blue", BirthYear = "47BBY", Gender = "female", PlanetID = 1 },                
                new CharacterEntity { Id = 8, Name = "R5-D4", Height = "97", Weight = "32", HairColor = "n/a", SkinColor = "white, red", EyeColor = "red", BirthYear = "unknown", Gender = "n/a", PlanetID = 1 },                
                new CharacterEntity { Id = 9, Name = "Biggs Darklighter", Height = "183", Weight = "84", HairColor = "black", SkinColor = "light", EyeColor = "brown", BirthYear = "24BBY", Gender = "male", PlanetID = 1 },                
                new CharacterEntity { Id = 10, Name = "Obi-Wan Kenobi", Height = "182", Weight = "77", HairColor = "auburn, white", SkinColor = "fair", EyeColor = "blue-gray", BirthYear = "57BBY", Gender = "male", PlanetID = 20 },                
                new CharacterEntity { Id = 11, Name = "Anakin Skywalker", Height = "188", Weight = "84", HairColor = "blond", SkinColor = "fair", EyeColor = "blue", BirthYear = "41.9BBY", Gender = "male", PlanetID = 1 },
            };
            modelBuilder.Entity<CharacterEntity>().HasData(characters);
        }
    }
}