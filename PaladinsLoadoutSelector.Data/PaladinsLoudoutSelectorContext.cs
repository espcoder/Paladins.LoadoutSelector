using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PaladinsDomain;

namespace PaladinsLoadoutSelector.Data
{
    public class PaladinsLoudoutSelectorContext : DbContext
    {
        public static readonly LoggerFactory MyLoggingFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<Champion> Champions { get; set; }
        public DbSet<Loadout> Loadouts { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<LoadoutCard> LoadoutCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggingFactory);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database = PaladinsData; Trusted_Connection = True; ");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoadoutCard>()
                .HasKey(lc => new { lc.CardId, lc.LoadoutId });

            base.OnModelCreating(modelBuilder);
        }
    }
}