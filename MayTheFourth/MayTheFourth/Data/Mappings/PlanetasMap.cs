using MayTheFourth.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Data.Mappings;

/// <summary>
/// PlanetaMAP
/// </summary>
public class PlanetasMap : IEntityTypeConfiguration<Planeta>
{
    /// <summary>
    /// Mapeamento da tabela
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Planeta> builder)
    {
        // Tabela
        builder.ToTable("Planeta");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.PeriodoRotacao)
            .IsRequired()
            .HasColumnName("PeriodoRotacao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.PeriodoOrbital)
            .IsRequired()
            .HasColumnName("PeriodoOrbital")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Diametro)
            .IsRequired()
            .HasColumnName("Diametro")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Clima)
            .IsRequired()
            .HasColumnName("Clima")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Gravidade)
            .IsRequired()
            .HasColumnName("Gravidade")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Terreno)
            .IsRequired()
            .HasColumnName("Terreno")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.SuperficieAquatica)
            .IsRequired()
            .HasColumnName("SuperficieAquatica")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Populacao)
            .IsRequired()
            .HasColumnName("Populacao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
    
        // Relacionamentos
        builder
            .HasMany(x => x.Personagens)
            .WithOne(x => x.Planeta)
            .HasConstraintName("FK_Planeta_Personagem")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(x => x.Filmes)
            .WithMany(x => x.Planetas)
            .UsingEntity<Dictionary<string, object>>(
                "FilmePlaneta",
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_Filme_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade),
                planeta => planeta
                    .HasOne<Planeta>()
                    .WithMany()
                    .HasForeignKey("PlanetaId")
                    .HasConstraintName("FK_PlanetaFilme_PlanetaId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}