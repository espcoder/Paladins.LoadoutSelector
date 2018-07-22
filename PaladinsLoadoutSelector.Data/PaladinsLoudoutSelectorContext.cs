using Microsoft.EntityFrameworkCore;
using PaladinsDomain;

namespace PaladinsLoadoutSelector.Data
{
    public class PaladinsLoudoutSelectorContext : DbContext
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Loadout> Loadouts { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database = PaladinsData; Trusted_Connection = True; ");
        }
    }
}