using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class StarshipConfiguration : IEntityTypeConfiguration<Starship>    
    {
        public void Configure(EntityTypeBuilder<Starship> builder)
        {
            builder.Property(s => s.Id)
                .HasColumnName("StarshipId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(s => s.HyperdriveRating)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(s => s.MaximumMegalights)
                .HasColumnType("integer")
                .IsRequired();

            builder.HasKey(s => s.Id);

        }


    }
}
