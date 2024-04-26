using MayTheFourth.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Data.Mappings;

public class NavesEstelaresMap : IEntityTypeConfiguration<NavesEstelares>
{
    public void Configure(EntityTypeBuilder<NavesEstelares> builder)
    {
        // Tabela
        builder.ToTable("NavesEstelares");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        // Propriedades
        builder.Property(x => x.Modelo)
            .IsRequired()
            .HasColumnName("Modelo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Fabricante)
            .IsRequired()
            .HasColumnName("Fabricante")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Custo)
            .IsRequired()
            .HasColumnName("Custo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Comprimento)
            .IsRequired()
            .HasColumnName("Comprimento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.VelocidadeMaxima)
            .IsRequired()
            .HasColumnName("VelocidadeMaxima")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Tripulacao)
            .IsRequired()
            .HasColumnName("Tripulacao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Passageiros)
            .IsRequired()
            .HasColumnName("Passageiros")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.CapacidadeCarga)
            .IsRequired()
            .HasColumnName("CapacidadeCarga")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.ClassificacaoHiperdrive)
            .IsRequired()
            .HasColumnName("ClassificacaoHiperdrive")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Mglt)
            .IsRequired()
            .HasColumnName("Mglt")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Consumiveis)
            .IsRequired()
            .HasColumnName("Consumiveis")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Classe)
            .IsRequired()
            .HasColumnName("Classe")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        // Relacionamentos
        builder
            .HasMany(x => x.Filmes)
            .WithMany(x => x.Naves)
            .UsingEntity<Dictionary<string, object>>(
                "PersonagemNavesEstelares",
                filme => filme
                    .HasOne<Filme>()
                    .WithMany()
                    .HasForeignKey("FilmeId")
                    .HasConstraintName("FK_Filme_FilmeId")
                    .OnDelete(DeleteBehavior.Cascade),
                nave => nave
                    .HasOne<NavesEstelares>()
                    .WithMany()
                    .HasForeignKey("NavesEstelaresId")
                    .HasConstraintName("FK_NavesEstelaresFilme_NavesEstelaresId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}