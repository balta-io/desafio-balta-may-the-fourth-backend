using Microsoft.EntityFrameworkCore;
using StarisApi.Models.Characters;

namespace StarisApi.DbContexts
{
    public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterDbMap());
        }
    }
}
