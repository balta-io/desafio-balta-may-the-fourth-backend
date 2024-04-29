using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Mappings;

/// <summary>
/// VeiculoMAP
/// </summary>
public class VeiculosMap : IEntityTypeConfiguration<Veiculo>
{
    /// <summary>
    /// Mapeamento da tabela
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        // Tabela
        builder.ToTable("Veiculo");

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

        builder.Property(x => x.Modelo)
            .IsRequired()
            .HasColumnName("Modelo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Fabricante)
            .IsRequired()
            .HasColumnName("Fabricante")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Custo)
            .IsRequired()
            .HasColumnName("Custo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Comprimento)
            .IsRequired()
            .HasColumnName("Comprimento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.VelocidadeMaxima)
            .IsRequired()
            .HasColumnName("VelocidadeMaxima")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Tripulacao)
            .IsRequired()
            .HasColumnName("Tripulacao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Passageiros)
            .IsRequired()
            .HasColumnName("Passageiros")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.CapacidadeCarga)
            .IsRequired()
            .HasColumnName("CapacidadeCarga")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Consumiveis)
            .IsRequired()
            .HasColumnName("Consumiveis")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Classe)
            .IsRequired()
            .HasColumnName("Classe")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        // Relacionamentos
        builder
            .HasMany(x => x.Filmes)
            .WithMany(x => x.Veiculos)
            .UsingEntity<Dictionary<string, object>>(
                "FilmePlaneta",
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_Filme_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade),
                veiculo => veiculo
                    .HasOne<Veiculo>()
                    .WithMany()
                    .HasForeignKey("VeiculoId")
                    .HasConstraintName("FK_VeiculoFilme_VeiculoId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}