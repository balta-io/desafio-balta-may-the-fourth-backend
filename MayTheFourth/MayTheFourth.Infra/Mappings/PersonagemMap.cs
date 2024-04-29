using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Mappings;

/// <summary>
/// PersonagemMAP
/// </summary>
public class PersonagemMap : IEntityTypeConfiguration<Personagem>
{
    /// <summary>
    /// Mapeamento da tabela
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Personagem> builder)
    {
        // Tabela
        builder.ToTable("Personagem");

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
            .HasMaxLength(100);

        builder.Property(x => x.Altura)
            .IsRequired()
            .HasColumnName("Altura")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Peso)
            .IsRequired()
            .HasColumnName("Peso")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.CorCabelo)
            .IsRequired()
            .HasColumnName("CorCabelo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.CorPele)
            .IsRequired()
            .HasColumnName("CorPele")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.CorOlhos)
            .IsRequired()
            .HasColumnName("CorOlhos")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.DataNascimento)
            .IsRequired()
            .HasColumnName("DataNascimento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Genero)
            .IsRequired()
            .HasColumnName("Genero")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        // Relacionamentos
        builder
            .HasOne(x => x.Planeta)
            .WithMany(x => x.Personagens)
            .HasConstraintName("FK_Personagem_Planeta")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Filmes)
            .WithMany(x => x.Personagens)
            .UsingEntity<Dictionary<string, object>>(
                "FilmePersonagem",
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_Filme_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade),
                personagem => personagem
                    .HasOne<Personagem>()
                    .WithMany()
                    .HasForeignKey("PersonagemId")
                    .HasConstraintName("FK_PersonagemFilme_PersonagemId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}