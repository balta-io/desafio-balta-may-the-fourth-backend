using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class PlanetCharacterConfiguration : IEntityTypeConfiguration<PlanetCharacter>
    {
        public void Configure(EntityTypeBuilder<PlanetCharacter> builder) 
        {
            builder.Property(cp => cp.CharacterId)
                .IsRequired();

            builder.Property(cp => cp.PlanetId)
                .IsRequired();

			builder.HasOne(c => c.Character)
				.WithMany(f => f.PlanetsOfResidence)
				.HasForeignKey(cf => cf.CharacterId)
				.HasConstraintName("fk_Characters_PlanetCharacters")
				.HasPrincipalKey(k => k.Id);

            builder.HasOne(f => f.Planet)
				.WithMany(c => c.Residents)
				.HasForeignKey(cf => cf.PlanetId)
				.HasConstraintName("fk_Planerts_PlanetCharacters")
				.HasPrincipalKey(pk => pk.Id);

			builder.HasKey(k => new { k.CharacterId, k.PlanetId });

			builder.ToTable("PlanetCharacters");



        }
    }
}
