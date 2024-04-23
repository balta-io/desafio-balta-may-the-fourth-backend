using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
    public class MoveConfiguration : IEntityTypeConfiguration<MoveModel>
    {

        public void Configure(EntityTypeBuilder<MoveModel> builder)
        {
            builder.ToTable("Move");
            builder.HasKey(x=> x.MoveId);
            builder.Property(x=> x.MoveId).ValueGeneratedOnAdd();
        }
    }
}

