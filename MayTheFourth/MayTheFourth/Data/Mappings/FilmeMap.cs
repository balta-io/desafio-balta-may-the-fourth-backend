using MayTheFourth.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Data.Mappings;

public class FilmeMap : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        // Tabela
        builder.ToTable("Filme");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        // Propriedades
        builder.Property(x => x.Titulo)
            .IsRequired()
            .HasColumnName("Titulo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
        
        builder.Property(x => x.Episodio)
            .IsRequired()
            .HasColumnName("Episodio")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
        
        builder.Property(x => x.Diretor)
            .IsRequired()
            .HasColumnName("Diretor")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Produtor)
            .IsRequired()
            .HasColumnName("Produtor")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.DataLancamento)
            .IsRequired()
            .HasColumnName("DataLancamento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        // Relacionamentos
        builder
            .HasMany(x => x.Personagens)
            .WithMany(x => x.Filmes)
            .UsingEntity<Dictionary<string, object>>(
                "PersonagemFilme",
                personagem => personagem
                    .HasOne<Personagem>()
                    .WithMany()
                    .HasForeignKey("PersonagemId")
                    .HasConstraintName("FK_Personagem_PersonagemId")
                    .OnDelete(DeleteBehavior.Cascade),
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_FilmePersonagem_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade));
        
        builder
            .HasMany(x => x.Planetas)
            .WithMany(x => x.Filmes)
            .UsingEntity<Dictionary<string, object>>(
                "PlanetaFilme",
                planeta => planeta
                    .HasOne<Planeta>()
                    .WithMany()
                    .HasForeignKey("PlanetaId")
                    .HasConstraintName("FK_Planeta_PlanetaId")
                    .OnDelete(DeleteBehavior.Cascade),
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_FilmePlaneta_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade));
        
        builder
            .HasMany(x => x.Veiculos)
            .WithMany(x => x.Filmes)
            .UsingEntity<Dictionary<string, object>>(
                "VeiculoFilme",
                veiculo => veiculo
                    .HasOne<Veiculo>()
                    .WithMany()
                    .HasForeignKey("VeiculoId")
                    .HasConstraintName("FK_Veiculo_VeiculoId")
                    .OnDelete(DeleteBehavior.Cascade),
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_FilmeVeiculo_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade));
        
        builder
            .HasMany(x => x.Naves)
            .WithMany(x => x.Filmes)
            .UsingEntity<Dictionary<string, object>>(
                "NavesEstelaresFilme",
                nave => nave
                    .HasOne<NavesEstelares>()
                    .WithMany()
                    .HasForeignKey("NavesEstelaresId")
                    .HasConstraintName("FK_NavesEstelares_NavesEstelaresId")
                    .OnDelete(DeleteBehavior.Cascade),
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_FilmeNavesEstelaresId_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}