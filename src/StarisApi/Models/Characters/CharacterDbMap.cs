using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Characters
{
    public class CharacterDbMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Characters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        }
    }
}
