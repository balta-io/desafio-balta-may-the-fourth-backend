using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class CharacterPlanetConfiguration : IEntityTypeConfiguration<CharacterPlanet>
    {
        public void Configure(EntityTypeBuilder<CharacterPlanet> builder) 
        {
            builder.Property(cp => cp.CharacterId)
                .IsRequired();

            builder.Property(cp => cp.PlanetId)
                .IsRequired();

            builder.Property(cp => cp.Planet);
            builder.Property(cp => cp.Character);

           
            
            builder.ToTable("PlanetFilm");



        }
    }
}
